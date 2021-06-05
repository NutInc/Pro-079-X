using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Pro079X
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
    }
}