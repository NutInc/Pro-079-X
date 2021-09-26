namespace Pro079XKeycardMalfunction
{
    using Exiled.API.Features;
    using Configs;
    using System;
    using Exiled.API.Interfaces;
    using Pro079X.Logic;
    using PlayerEvent = Exiled.Events.Handlers.Player;
    public class Pro079XKeycardMalfunction : Plugin<Config, Translations>
    {
        public override string Author { get; } = "NutInc";
        public override string Name { get; } = "Pro079XKeycardMalfunction";
        public override string Prefix { get; } = "pro_079_keycard_malfunction";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        
        public static Pro079XKeycardMalfunction Singleton;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;
            PlayerEvent.InteractingDoor += EventHandlers.OnInteractDoor;
            Manager.RegisterUltimate(new KeycardMalfunctionCommand());
        }

        public override void OnDisabled()
        {
            PlayerEvent.InteractingDoor -= EventHandlers.OnInteractDoor;
            Singleton = null;
            base.OnDisabled();
        }
    }
}