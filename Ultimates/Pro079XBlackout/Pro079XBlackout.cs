namespace Pro079XBlackout
{
    using Pro079X.Configs;
    using System;
    using Exiled.API.Features;
    using Pro079X.Logic;
    using Configs;
    public class Pro079XBlackout : Plugin<Configs.Config>
    {
        public override string Author { get; } = "Nut Inc";
        public override string Name { get; } = "Pro079XBlackout";
        public override string Prefix { get; } = "pro_079_blackout";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public static Pro079XBlackout Singleton;
        internal Pro079X.Configs.Translations Translations;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Singleton = this;

            Translations = new Pro079X.Configs.Translations();
 
            Log.Debug($"Loaded in backout: {Manager.RegisterUltimate(new BlackoutCommand())}");
        }

        public override void OnDisabled()
        {
            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }
    }
}