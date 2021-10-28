namespace Pro079X
{
    using Exiled.API.Enums;
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
    
    public class Pro079X : Plugin<Config, Translations>
    {
        public static Pro079X Singleton;
        private PlayerHandlers _playerHandlers;
        private ServerHandlers _serverHandlers;
        //
        public override string Author { get; } = "NutInc";
        public override string Name { get; } = "Pro079X";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override PluginPriority Priority { get; } = PluginPriority.First;


        public override void OnEnabled()
        {
            Singleton = this;
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
            
            Singleton = null;
            base.OnDisabled();
        }

        public override void OnReloaded(){}
        
        private void RegisterEvents()
        {
            PlayerEvents.ChangingRole += _playerHandlers.OnChangingRole;
            PlayerEvents.Died += _playerHandlers.OnDied;
            PlayerEvents.Spawning += _playerHandlers.OnSpawning; 
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