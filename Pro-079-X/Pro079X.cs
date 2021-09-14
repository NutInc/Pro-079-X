using Exiled.API.Enums;

namespace Pro079X
{
    using Commands;
    using Configs;
    using Exiled.API.Features;
    using Handlers;
    using Logic;
    using MEC;
    using System;
    using System.IO;
    using PlayerEvents = Exiled.Events.Handlers.Player;
    using ServerEvents = Exiled.Events.Handlers.Server;
    
    public class Pro079X : Plugin<Config>
    {
        public static Pro079X Singleton;
        public Translations Translations;
        private PlayerHandlers _playerHandlers;
        private ServerHandlers _serverHandlers;
        
        public override string Author { get; } = "Nut Inc Development";
        public override string Name { get; } = "Pro079X";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override PluginPriority Priority { get; } = PluginPriority.First;


        public override void OnEnabled()
        {
            Config.TranslationsDirectory = Path.Combine(Paths.Configs, "Pro079XTranslations.yml");
            Log.Debug("Path: " + Config.TranslationsDirectory);
            if (!File.Exists(Config.TranslationsDirectory))
            {
                try
                {
                    Log.Info("Translation directory does not exist! Attempting to create directory!");
                    File.Create(Config.TranslationsDirectory).Close();
                }
                catch (Exception e)
                {
                    Log.Error("There was an error: " + e);
                }
            }
            
            Singleton = this;
            Translations = new Translations();
            Manager.LoadTranslations();
            _playerHandlers = new PlayerHandlers();
            _serverHandlers = new ServerHandlers();
            RegisterEvents();
            if (Config.SuicideCommand)
                Manager.RegisterCommand(new SuicideCommand());
            if (Config.EnableTips)
                Manager.RegisterCommand(new TipsCommand());
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            _playerHandlers = null;
            _serverHandlers = null;
            foreach (var coroutineHandle in Manager.CoroutineHandles)
                Timing.KillCoroutines(coroutineHandle);

            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded(){}
        
        private void RegisterEvents()
        {
            PlayerEvents.ChangingRole += _playerHandlers.OnChangingRole;
            PlayerEvents.Died += _playerHandlers.OnDied;
            ServerEvents.WaitingForPlayers += _serverHandlers.OnWaitingForPlayers;
        }

        private void UnRegisterEvents()
        {
            PlayerEvents.ChangingRole -= _playerHandlers.OnChangingRole;
            PlayerEvents.Died -= _playerHandlers.OnDied;
            ServerEvents.WaitingForPlayers -= _serverHandlers.OnWaitingForPlayers;
        }
        
    }
}