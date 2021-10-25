using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Pro079XTesla.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public int Cooldown { get; set; } = 50;
        public int Cost { get; set; } = 50;
        public int Level { get; set; } = 2;

        [Description("Gives one experience point per second disabled while this is enabled.")]
        public bool GrantExperience { get; set; } = true;
    }
}