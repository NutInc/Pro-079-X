using System;
using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace Pro079X
{
    public static class EventHandlers
    {
        public static void OnRoleChange(ChangingRoleEventArgs ev)
        {
            
        }

        public static void OnDying(DyingEventArgs ev)
        {
            Log.Debug($"Player who died: {ev.Target.Role}");
            if (ev.Target.Role != RoleType.Scp079)
            {
                ev.IsAllowed = true;
                return;
            }
            
            ev.Target.SetRole(RoleType.Scp93953); 
            ev.IsAllowed = false;
        }
    }
}