using Exiled.Events.EventArgs;

namespace Pro079XTesla
{
    public class EventHandlers
    {
        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            ev.IsTriggerable = !Pro079XTesla.Singleton.IsActive;
        }
    }
}