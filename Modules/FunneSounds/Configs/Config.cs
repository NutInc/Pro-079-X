namespace FunneSounds.Configs
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;
    
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        public int Cooldown { get; set; } = 5;
        
        public int Cost { get; set; } = 10;
        
        public int Level { get; set; } = 1;
    }
}