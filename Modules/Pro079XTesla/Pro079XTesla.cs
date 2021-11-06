using Exiled.API.Features;
using MEC;
using Pro079X.Logic;
using System;
using Pro079XTesla.Configs;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace Pro079XTesla
{
    public class Pro079XTesla : Plugin<Config, Translations>
    {
        internal static Pro079XTesla Singleton;
        internal Translations Translations;
        internal bool IsActive = true;
        public override string Prefix { get; } = "pro_079X_tesla";

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            base.OnEnabled();
            PlayerEvents.TriggeringTesla += EventHandlers.OnTriggeringTesla;
            Manager.RegisterCommand(new TeslaCommand());
        }

        public override void OnDisabled()
        {
            PlayerEvents.TriggeringTesla -= EventHandlers.OnTriggeringTesla;
            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }

        public override string Author => "NutInc";
        public override string Name { get; } = "Pro079XTesla";

        public override Version Version => new Version(4, 0, 0);
    }
}