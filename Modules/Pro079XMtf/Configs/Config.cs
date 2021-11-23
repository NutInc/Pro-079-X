using Exiled.API.Interfaces;

namespace Pro079XMtf.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int Cooldown { get; set; } = 50;
        public int Cost { get; set; } = 50;
        public int Level { get; set; } = 2;
        public int MaxScp { get; set; } = 5;
    }
}