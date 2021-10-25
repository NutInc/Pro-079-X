using System;
using CommandSystem;
using Pro079X.Interfaces;

namespace Pro079XInfo
{
    public class InfoCommand : ICommand079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Not implemented yet";
            return false;
        }

        public string Command { get; }
        public string[] Aliases { get; }
        public string Description { get; }
        public string ExtraArguments { get; }
        public bool Cassie { get; }
        public int Cooldown { get; }
        public int MinLevel { get; }
        public int Cost { get; }
        public string CommandReady { get; }
    }
}