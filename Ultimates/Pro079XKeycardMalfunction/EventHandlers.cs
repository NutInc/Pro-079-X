using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;

namespace Pro079XKeycardMalfunction
{
    public static class EventHandlers
    {
        public static bool KeycardsBroken = false;

        public static void OnInteractDoor(InteractingDoorEventArgs ev)
        {
            if (!KeycardsBroken) return;
            if (!ev.IsAllowed) return;
            if (ev.Door.RequiredPermissions.RequiredPermissions == KeycardPermissions.None) return;
            ev.IsAllowed = false;
            ev.Player.ShowHint( "Keycard Malfunction! Please wait for them to be fixed.");
        }
    }
}