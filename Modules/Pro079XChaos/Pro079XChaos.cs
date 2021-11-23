using System;
using Exiled.API.Features;
using Pro079X.Logic;
using Pro079XChaos.Configs;

namespace Pro079XChaos
{
    public class Pro079XChaos : Plugin<Config, Translations>
    {
        public override string Author => "NutInc";
        public override Version Version => new Version(4, 0, 0);
        public override string Name { get; } = "Pro079XChaos";
        public override string Prefix { get; } = "pro_079X_chaos";
        internal static Pro079XChaos Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            base.OnEnabled();
            Manager.RegisterCommand(new ChaosCommand());
        }
    }
}