namespace Pro079XGrenade
{
    using System;
    using CommandSystem;
    using Pro079X.Interfaces;
    public class GrenadeSpawn : IUltimate079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Not implemented yet";
            return true;
        }

        public string Command { get; } = Pro079XGrenade.Plugin.Singleton.Translations.Command;
        public string[] Aliases { get; }
        public string Description { get; }
        public int Cooldown { get; }
        public int Cost { get; }
    }
}