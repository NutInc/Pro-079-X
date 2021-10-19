namespace Pro079XGenerators.Configs
{
    using Pro079X.Interfaces;
    
    public class Translations
    {
        public string Command { get; set; } = "gen";
        public string CommandReady { get; set; } = "<b>Generator command ready</b>";
        public string Description { get; set; } = "Fakes the specified generator activation sequence.";
        public string Usage { get; set; }
    }
}