using Exiled.API.Interfaces;

namespace Pro079XChaos.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int Cooldown { get; set; } = 50;
        public int Cost { get; set; } = 50;
        public int Level { get; set; } = 2;
        public string BroadcastMessage { get; set; } = "warning . chaosinsurgency detected in the surface";
    }
}