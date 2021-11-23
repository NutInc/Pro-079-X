using Exiled.API.Interfaces;

namespace Pro079XKeycardMalfunction.Configs
{
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "keymal";
        public string Description { get; set; } = "Causes the facility to not be able to use keycards for a set duration.";
        
        public string Usage { get; set; } = ".079 ultimate keymal";

        public string CassieStartMessage { get; set; } = "Key card Malfunction....";

        public string CassieEndMessage { get; set; } = "Key card work now";
    }
}