namespace Pro079XGrenade.Configs
{
    using Exiled.API.Interfaces;
    
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "grenade";
        public string Description { get; set; } = "Spawns in a grenade in a certain room.";
        public string Usage { get; set; } = ".079 ultimate grenade";
    }
}