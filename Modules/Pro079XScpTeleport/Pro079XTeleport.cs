using Exiled.API.Features;
using System;
using Pro079XTeleport.Configs;

namespace Pro079XTeleport
{
    public class Pro079XTeleport : Plugin<Config, Translations>
    {
        internal static Pro079XTeleport Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            /*if (!Manager.RegisterCommand(new GeneratorCommand()))
                OnDisabled();*/

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Translations = null;
            base.OnDisabled();
        }

        public override string Author { get; } = "NutInc";
        public override string Name { get; } = "Pro079XTeleport";
        public override Version Version => new Version(4, 0, 0);
    }
}