using System;
using Exiled.API.Features;
using Pro079X.Configs;
using Pro079X.Logic;
using Config = Pro079XScp.Configs.Config;

namespace Pro079XScp
{
    public class Pro079XScp : Plugin<Config, Translations>
    {
        internal static Pro079XScp Singleton;
        internal Configs.Translations Translations;
        public override string Prefix { get; } = "pro_079X_scp";

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Configs.Translations();
            Manager.RegisterCommand(new ScpCommand());

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Translations = null;
            base.OnDisabled();
        }

        public override string Author => "NutInc";
        public override Version Version => new Version(4, 0, 0);
    }
}