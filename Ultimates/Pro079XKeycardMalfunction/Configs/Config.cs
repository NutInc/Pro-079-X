namespace Pro079XKeycardMalfunction.Configs
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;
    
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public int Duration { get; set; } = 30;

        public int Cooldown { get; set; } = 60;

        public int Cost { get; set; } = 50;
    }
}