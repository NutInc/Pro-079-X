namespace Pro079XGrenade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.API.Features.Items;
    using Pro079X.Interfaces;
    using CommandSystem;
    public class GrenadeSpawnCommand : IUltimate079
    {
        public string Command { get; } = Pro079XGrenade.Singleton?.Translation.Command;

        public string[] Aliases { get; } = Array.Empty<string>();
        
        public string Description { get; } = Pro079XGrenade.Singleton?.Translation.Description;
        public int Cooldown { get; } = Pro079XGrenade.Singleton.Config.Cooldown;
        public int Cost { get; } = Pro079XGrenade.Singleton.Config.Cost;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            List<Player> players = ply.CurrentRoom.Players.Where(player=>player.Team!=Team.SCP).ToList();
            
            if (players.Count > 0)
            {
                ExplosiveGrenade exp = new ExplosiveGrenade(ItemType.GrenadeHE, ply);
                exp.ScpMultiplier = 0;
                exp.FuseTime = 1;
                exp.SpawnActive(players[0].Position);
                response = "funne";
                return true;
            }

            response = "Nobody is in this room!";
            return false;
        }
    }
}