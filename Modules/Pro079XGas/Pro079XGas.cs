using System;
using Exiled.API.Features;
using Pro079X.Logic;
using Pro079XGas.Configs;

namespace Pro079XGas
{
    public class Pro079XGas : Plugin<Config, Translations>
    {
        public override string Author => "NutInc";
        public override Version Version => new Version(4, 0, 0);
        public override string Name { get; } = "Pro079XGas";
        public override string Prefix { get; } = "pro_079X_gas";
        internal static Pro079XGas Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            base.OnEnabled();
            Manager.RegisterCommand(new GasCommand());
        }
        
        public override void OnDisabled()
        {
            base.OnDisabled();
            Singleton = null;
            Translations = null;
        }
    }
}