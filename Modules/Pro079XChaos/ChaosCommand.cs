using System;
using CommandSystem;
using Pro079X.Interfaces;

namespace Pro079XChaos
{
    public class ChaosCommand : ICommand079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Exiled.API.Features.Cassie.Message(Pro079XChaos.Singleton.Config.BroadcastMessage);
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }

        public string Command => Pro079XChaos.Singleton.Translations.Command;
        public string[] Aliases => Array.Empty<string>();
        public string Description => Pro079XChaos.Singleton.Translations.Description;

        public string ExtraArguments => string.Empty;
        public bool Cassie => true;
        public int Cooldown => Pro079XChaos.Singleton.Config.Cooldown;
        public int MinLevel => Pro079XChaos.Singleton.Config.Level;
        public int Cost => Pro079XChaos.Singleton.Config.Cost;
        public string CommandReady => Pro079XChaos.Singleton.Translations.CommandReady;
    }
}