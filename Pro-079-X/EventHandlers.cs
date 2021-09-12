using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Pro079X.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pro079X
{
    public static class EventHandlers
    {
        public static void OnRoleChange(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole != RoleType.Scp079)
            {
                Manager.CassieCooldowns.Remove(ev.Player);
                return;
            }

            Manager.CassieCooldowns[ev.Player] = DateTime.Now;
            Manager.UltimateCooldowns[ev.Player] = DateTime.Now;

            if (Pro079X.Singleton.Config.EnableSpawnBroadcast)
            {
                ev.Player.ClearBroadcasts();
                ev.Player.Broadcast(10, "");
            }

            ev.Player.SendConsoleMessage("", "white");
        }
        
        public static void OnDied(DiedEventArgs ev)
        {
            if (!Pro079X.Singleton.Config.SuicideCommand)
                return;

            List<Player> pcPlayers = Player.Get(RoleType.Scp079).ToList();
            int pcCount = pcPlayers.Count;
            if (ev.Target.Team != Team.SCP ||
                ev.Target.Role == RoleType.Scp079 ||
                pcCount < 0 ||
                Player.Get(Team.SCP).Count() - pcCount > 0)
                return;

            Manager.CanSuicide = true;
            if (string.IsNullOrEmpty(Pro079X.Singleton.Translations.Kys))
                return;

            for (int i = 0; i < pcCount; i++)
                pcPlayers[i].Broadcast(5, "");
        }
        
        public static void OnWaitingForPlayers()
        {
            Manager.CassieCooldowns.Clear();
            Manager.CommandCooldowns.Clear();
            Manager.UltimateCooldowns.Clear();
            Manager.CanSuicide = false;
        }
    }
}