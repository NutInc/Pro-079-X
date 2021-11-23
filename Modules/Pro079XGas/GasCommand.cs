using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Pro079X.Interfaces;

namespace Pro079XGas
{
    public class GasCommand : ICommand079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            Room room = Map.FindParentRoom(ply.GameObject);
            if (!room.Players.Any() || room.Players.All(player => player.IsHuman))
            {
                response = Pro079XGas.Singleton.Translations.NoPlayersFound;
                return false;
            }

            foreach (Player player in room.Players.Where(player => player.Team != Team.SCP))
            {
                player.EnableEffect<CustomPlayerEffects.Decontaminating>(3f);
            }

            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }

        public string Command => Pro079XGas.Singleton.Translations.Command;
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description => Pro079XGas.Singleton.Translations.Description;
        public string ExtraArguments { get; } = string.Empty;
        public bool Cassie => false;
        public int Cooldown => Pro079XGas.Singleton.Config.Cooldown;
        public int MinLevel => Pro079XGas.Singleton.Config.Level;
        public int Cost => Pro079XGas.Singleton.Config.Cost;
        public string CommandReady => Pro079XGas.Singleton.Translations.CommandReady;
    }
}