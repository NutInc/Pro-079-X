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
        public string Command => Pro079XGrenade.Singleton?.Translation.Command;

        public string[] Aliases { get; } = Array.Empty<string>();
        
        public string Description => Pro079XGrenade.Singleton?.Translation.Description;
        public int Cooldown => Pro079XGrenade.Singleton.Config.Cooldown;
        public int Cost => Pro079XGrenade.Singleton.Config.Cost;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            List<Player> players = ply.CurrentRoom.Players.ToList();
            
            if (players[0] != null)
            {
                ExplosiveGrenade exp = new ExplosiveGrenade(ItemType.GrenadeHE, ply);
                exp.ScpMultiplier = 0;
                exp.FuseTime = 0;
                exp.SpawnActive(players[0].Position);
                response = "funne";
                return true;
            }

            response = "Nobody is in this room!";
            return false;
        }
    }
}