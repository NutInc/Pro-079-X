namespace FunneSounds
{
    using System;
    using CommandSystem;
    using Pro079X.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using PlayableScps.Messages;
    public class FunneSoundsCommand : ICommand079
    {
        public string Command { get; } = FunneSounds.Singleton.Translation.Command;
        public string[] Aliases { get; }
        public string Description { get; } = FunneSounds.Singleton.Translation.Usage;
        public string ExtraArguments { get; }
        
        public bool Cassie { get; }
        public int Cooldown { get; } = FunneSounds.Singleton.Config.Cooldown;
        public int MinLevel { get; } = FunneSounds.Singleton.Config.Level;
        public int Cost { get; } = FunneSounds.Singleton.Config.Cost;
        public string CommandReady { get; }
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            List<Player> players = ply.CurrentRoom.Players.ToList();
            if (players.All(player => player.Team == Team.SCP))
            {
                response = "No players in this room..";
                return false;
            }

            if (Player.List.Any(player => player.Role != RoleType.Scp096))
            {
                response = "There is no 096 in this game..";
            }
            
            foreach (var player in players)
            {
                ply.ReferenceHub.characterClassManager.netIdentity.connectionToClient.Send(new Scp096ToTargetMessage(player.ReferenceHub), 0);
            }

            response = "Success! All the players in the room heard a funne sound!";
            return true;
        }
    }
}