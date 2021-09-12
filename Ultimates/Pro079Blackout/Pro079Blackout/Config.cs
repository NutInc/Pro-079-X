using System.ComponentModel;

namespace Pro079Blackout
{
    using Exiled.API.Interfaces;
    
    public class Config : IConfig
    {
        [Description("Is the plugin enable?")]
        public bool IsEnabled { get; set; } = true;
    }
}