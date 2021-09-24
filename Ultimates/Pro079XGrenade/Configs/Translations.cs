namespace Pro079XGrenade.Configs
{
    using Pro079X.Interfaces;
    
    public class Translations : ITranslations
    {
        public string Command { get; set; } = "grenade";
        public string Description { get; set; } = "Spawns in a grenade in a certain room.";
        public string Usage { get; set; } = ".079 ultimate grenade";
    }
}