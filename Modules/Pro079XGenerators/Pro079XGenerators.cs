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
            if (!Manager.RegisterCommand(new GeneratorCommand()))
                OnDisabled();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Translations = null;
            base.OnDisabled();
        }

        public override string Author => "NutInc";
        public override Version Version => new Version(4, 0, 0);
    }
}