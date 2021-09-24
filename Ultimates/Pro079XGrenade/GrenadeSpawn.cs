namespace Pro079XGrenade
{
    using System;
    using CommandSystem;
    using Pro079X.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.API.Features.Items;

    public class GrenadeSpawn : IUltimate079
    {
        public string Command { get; } = Pro079XGrenade.Plugin.Singleton.Translations.Command;
        
        public string[] Aliases { get; }
        
        public string Description { get; } = Pro079XGrenade.Plugin.Singleton.Translations.Description;
        public int Cooldown { get; } = Pro079XGrenade.Plugin.Singleton.Config.Cooldown;
        public int Cost { get; } = Pro079XGrenade.Plugin.Singleton.Config.Cooldown;
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