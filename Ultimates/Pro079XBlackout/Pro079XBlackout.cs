namespace Pro079XBlackout
{
    using Pro079X.Interfaces;
    using Pro079X.Configs;
    using System;
    using Exiled.API.Features;
    using Pro079X.Logic;
    
    public class Pro079XBlackout : Plugin<Configs.Config>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "Pro079XBlackout";
        public override string Prefix { get; } = "pro_079_blackout";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public static Pro079XBlackout Singleton;
        internal ITranslations Translations;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;

            Translations = new Configs.Translations();

            Manager.RegisterUltimate(new BlackoutCommand());
        }

        public override void OnDisabled()
        {
            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}