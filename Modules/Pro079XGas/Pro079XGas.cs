namespace Pro079XGas
{
    using Exiled.API.Features;
    using Configs;
    using System;
    using Pro079X.Logic;
    public class Pro079XGas : Plugin<Config,Translations>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "Pro079XGas";
        public override string Prefix { get; } = "pro_079X_gas";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        
        public static Pro079XGas Singleton;
        
        public override void OnEnabled()
        {
            Singleton = this;
        }

        public override void OnDisabled()
        {

        }
    }
}