using System;
using Exiled.API.Features;
using Pro079X.Logic;
using Pro079XMtf.Configs;

namespace Pro079XMtf
{
    public class Pro079XMtf : Plugin<Config, Translations>
    {
        internal static Pro079XMtf Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            base.OnEnabled();
            Manager.RegisterCommand(new MtfCommand());
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Translations = null;
            base.OnDisabled();
        }

        public override string Author => "NutInc";
        public override string Name { get; } = "Pro079XMtf";
        public override Version Version => new Version(4, 0, 0);
    }
}