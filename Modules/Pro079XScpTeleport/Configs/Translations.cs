using Exiled.API.Interfaces;

namespace Pro079XTeleport.Configs
{
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "teleport";
        public string CommandReady { get; set; } = "<b>Teleport command ready</b>";
        public string Description { get; set; } = "Moves the Scp079's camera to a specific scp(base game only and not zombies)";
        public string Usage { get; set; } = ".079 teleport <scp number>";

        public string InvalidRoleMessage { get; set; } = "Invalid Role!";

        public string ScpNotInGameMessage { get; set; } = "The scp is not in the game!";
    }
}