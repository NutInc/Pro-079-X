using Pro079X.Commands;
using Pro079X.Configs;
using Exiled.API.Features;
using Pro079X.Logic;
using MEC;
using System;
using System.IO;
using Pro079.Commands;
using Pro079X.Commands.SubCommands;
using PlayerHandlers = Exiled.Events.Handlers.Player;
using ServerHandlers = Exiled.Events.Handlers.Server;

namespace Pro079X
{
    public class Pro079X : Plugin<Config>
    {
        public static Pro079X Singleton;
        public Translations Translations;
        
        public override string Author { get; } = "Parkeymon and RedRanger";
        public override string Name { get; } = "Pro079X";
        public override Version Version { get; } = new Version(1, 0, 0);
        

        public override void OnEnabled()
        {
            if (!File.Exists(Config.TranslationsDirectory))
            {
                File.Create(Config.TranslationsDirectory).Close();
            }
            
            Singleton = this;
            Manager.LoadTranslations();
            Translations = new Translations();
            
            Manager.LoadTranslations();

            RegisterEvents();
            if (Config.SuicideCommand)
            {
                Manager.RegisterCommand(new SuicideCommand());
            }
                
            if (Config.EnableTips)
                Manager.RegisterCommand(new TipsCommand());
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();

            foreach (var coroutineHandle in Manager.CoroutineHandles)
            {
                Timing.KillCoroutines(coroutineHandle);
            }
            
            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded(){}
        
        private void RegisterEvents()
        {
            PlayerHandlers.ChangingRole += EventHandlers.OnRoleChange;
        }

        private void UnRegisterEvents()
        {
            PlayerHandlers.ChangingRole -= EventHandlers.OnRoleChange;
            PlayerHandlers.Died -= EventHandlers.OnDied;
            ServerHandlers.WaitingForPlayers -= EventHandlers.OnWaitingForPlayers;
        }
        
    }
}