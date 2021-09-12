namespace Pro079XBlackout.Configs
{
    using Pro079X.Interfaces;
    
    public class Translations : ITranslations
    {
        public string Command { get; set; } = "blackout";
        public string Description { get; set; } = "Shuts the facility down for {min} minute$";
        public string Usage { get; set; } = ".079 ultimate blackout";
    }
}