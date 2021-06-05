using System;

namespace Pro079X
{
    using Exiled.API.Features;

    using PlayerHandlers = Exiled.Events.Handlers.Player;
    
    public class Pro079X : Plugin<Config>
    {
        public override string Author { get; } = "Parkeymon";
        public override string Name { get; } = "Pro079X";
        public override Version Version { get; } = new Version(1, 0, 0);
        
        public static Pro079X Singleton;

        public override void OnEnabled()
        {
            Singleton = this;

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            
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
        }
        
    }
}