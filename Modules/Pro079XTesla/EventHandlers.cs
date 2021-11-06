using Exiled.Events.EventArgs;
using Exiled.API.Features;
using UnityEngine;

namespace Pro079XTesla
{
    public class EventHandlers
    {
        public static void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            Log.Debug("OnTriggering tesla invoked.");
            Log.Debug($"Value of isTriggerable: {!Pro079XTesla.Singleton.IsActive}");
            //if(ev.Player.Team != Team.SCP) return;
            
            ev.IsTriggerable = !Pro079XTesla.Singleton.IsActive;
        }
    }
}