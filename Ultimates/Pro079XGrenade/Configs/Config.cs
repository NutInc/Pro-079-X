namespace Pro079XGrenade.Configs
{
    using Exiled.API.Interfaces;
    
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public int Cooldown { get; set; } = 30;

        public int Cost { get; set; } = 75;
    }
}