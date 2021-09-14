namespace Pro079XBlackout.Configs
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    
    public class Config : IConfig
    {
        [Description("Is the blackout ability enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("The message CASSIE should say when a blackout is engaged.")]
        public string BlackoutCassieMessage { get; set; } =
            "Warning . Malfunction detected on heavy containment zone . Scp079Recon6 . . . light system disengaged";
        
        [Description("The cooldown time for the command")]
        public int Cooldown { get; set; } = 180;
        
        [Description("The duration of the blackout")]
        public int BlackoutDuration { get; set; } = 60;
        
        [Description("The amount of AHP it costs 079 to runt the command")]
        public int Cost { get; set; } = 50;
    }
}