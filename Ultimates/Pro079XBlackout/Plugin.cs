namespace Pro079XBlackout
{
    using System;
    using Exiled.API.Features;
    using Pro079X.Logic;
    
    public class Plugin : Plugin<Configs.Config, Configs.Translations>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "Pro079XBlackout";
        public override string Prefix { get; } = "pro079x_blackout";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public static Plugin Singleton;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;
            
            Manager.RegisterUltimate(new BlackoutCommand());
        }

        public override void OnDisabled()
        {
            Singleton = null;
            base.OnDisabled();
        }
    }
}