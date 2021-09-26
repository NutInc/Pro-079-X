namespace FunneSounds.Configs
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;
    
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "fakesound";
        public string Description { get; set; } = "plays a fake sound for a specifc player";
        public string Usage { get; set; } = ".079 ultimate fakesound";
    }
}