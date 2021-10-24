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
    }
}