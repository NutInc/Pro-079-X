using System.Collections.Generic;

namespace Pro079X.Configs
{
    using Exiled.API.Interfaces;
    using System.ComponentModel;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public string TranslationsDirectory { get; set; } 

        [Description("Enables use of the suicide command.")]
        public bool SuicideCommand { get; set; } = true;

        [Description("Enables use of the tips command.")]
        public bool EnableTips { get; set; } = true;

        [Description("Allows or disallows the loading of modules.")]
        public bool EnableModules { get; set; } = true;

        [Description("Allows or disallows the loading of ultimates.")]
        public bool EnableUltimates { get; set; } = true;

        [Description("Minimum level to use ultimates when enabled.")]
        public int UltimateLevel { get; set; } = 4;

        [Description("Toggles the use of a cooldown on cassie commands.")]
        public bool EnableCassieCooldown { get; set; } = true;

        [Description("The cooldown in seconds for commands that use cassie.")]
        public int CassieCooldown { get; set; } = 30;

        [Description("Enables the broadcast used when a 079 spawns.")]
        public bool EnableSpawnBroadcast { get; set; } = true;
        
        [Description("Doesnt let people with steam or discord ids use 079 at all")]
        public List<string> BlacklistedIds { get; set; } = new List<string>()
        {
            "76561198309681901@steam"
        };
    }
}