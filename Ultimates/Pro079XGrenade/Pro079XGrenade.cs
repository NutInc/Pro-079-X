namespace Pro079XGrenade
{
    using System;
    using Exiled.API.Features;
    using Exiled.Events;
    using Pro079X.Interfaces;
    using Pro079X.Logic;

    public class Pro079XGrenade : Plugin<Configs.Config>
    {
        public override string Author { get; } = "NutInc";
        public override string Name { get; } = "Pro079XGrenade";
        public override string Prefix { get; } = "pro_079_grenade";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);
        
        public static Pro079XGrenade Singleton;
        internal ITranslations Translations;
        
        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;

            Translations = new Configs.Translations();
            Manager.RegisterUltimate(new GrenadeSpawnCommand());
        }
    }
}