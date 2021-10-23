namespace Pro079XGenerators
{
    using Configs;
    using System;
    using Exiled.API.Features;
    using Pro079X.Logic;
    
    public class Pro079XGenerators : Plugin<Config, Translations>
    {
        internal static Pro079XGenerators Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            base.OnEnabled();
            Manager.RegisterCommand(new GeneratorCommand());
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Translations = null;
            base.OnDisabled();
        }

        public override string Author => "NutInc";
        public override string Name { get; } = "Pro079XGenerators";
        public override Version Version => new Version(4, 0, 0);
    }
}