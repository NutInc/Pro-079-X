namespace FunneSounds
{
    using System;
    using Exiled.API.Interfaces;
    using Exiled.API.Features;
    using Pro079X.Logic;
    
    public class FunneSounds : Plugin<Configs.Config, Configs.Translations>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "FunneSounds";
        public override string Prefix { get; } = "funne_sounds";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        
        public static FunneSounds Singleton;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;
            
            Manager.RegisterCommand(new FunneSoundsCommand());
        }

        public override void OnDisabled()
        {
            Singleton = null;
            base.OnDisabled();
        }
    }
}