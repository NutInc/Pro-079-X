namespace Pro079XGrenade.Configs
{
    using Pro079X.Interfaces;
    public class Translations : ITranslations
    {
        public string Command { get; set; } = "grenade";
        public string Description { get; set; }
        public string Usage { get; set; }
    }
}