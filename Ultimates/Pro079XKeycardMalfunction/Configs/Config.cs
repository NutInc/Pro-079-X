using Exiled.API.Interfaces;

namespace Pro079XKeycardMalfunction.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public int Cooldown { get; set; } = 30;

        public int Cost { get; set; } = 75;

        public int Duration { get; set; } = 20;
    }
}