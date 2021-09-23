using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Items;

namespace Pro079XGrenade
{
    using System;
    using CommandSystem;
    using Pro079X.Interfaces;
    using System.Collections.Generic;
    public class GrenadeSpawn : IUltimate079
    {
        public string Command { get; } = Pro079XGrenade.Plugin.Singleton.Translations.Command;
        public string[] Aliases { get; }
        public string Description { get; } = Pro079XGrenade.Plugin.Singleton.Translations.Description;
        public int Cooldown { get; }
        public int Cost { get; }
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            List<Player> players = ply.CurrentRoom.Players.ToList();
            new ExplosiveGrenade(ItemType.SCP018, ply).SpawnActive(players[0].Position, ply);
            response = "Not implemented yet";
            return true;
        }
    }
}