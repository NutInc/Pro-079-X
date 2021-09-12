namespace Pro079XBlackout
{
    using Configs;
    using System;
    using Exiled.API.Features;
    using Pro079X.Logic;

    public class Pro079XBlackout : Plugin<Config>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "Pro079XBlackout";
        public override string Prefix { get; } = "scplist";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        internal static Pro079XBlackout Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;

            Translations = new Translations();

            if (!Manager.RegisterUltimate(new BlackoutCommand()));
                OnDisabled();
                
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}