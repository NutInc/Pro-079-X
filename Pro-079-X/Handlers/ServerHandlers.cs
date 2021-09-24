namespace Pro079X.Handlers
{
    using Logic;
    using Exiled.Events.EventArgs;
    public class ServerHandlers
    {
        public void OnWaitingForPlayers()
        {
            Manager.CassieCooldowns.Clear();
            Manager.CommandCooldowns.Clear();
            Manager.UltimateCooldowns.Clear();
            Manager.CanSuicide = false;
        }

        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.RoleType == RoleType.Scp079)
            {
                ev.Player.Broadcast(5, "Type .079 help to unlock your full potential!");
            }
        }
    }
}