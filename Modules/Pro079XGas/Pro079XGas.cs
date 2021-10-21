using System;
using Exiled.API.Features;
using Pro079XGas.Configs;

namespace Pro079XGas
{
    public class Pro079XGas : Plugin<Config, Translations>
    {
        public override string Author => "NutInc";
        public override Version Version => new Version(4, 0, 0);
        internal static Pro079XGas Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
        }
    }
}