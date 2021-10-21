using Exiled.API.Interfaces;

namespace Pro079XGas.Configs
{
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "gas";
        public string CommandReady { get; set; } = "<b>Gas command ready</b>";
        public string Description { get; set; } = "Gasses all players in the room Scp079 is looking in";
        public string Usage { get; set; } = ".079 gas";
        public string NoPlayersFound { get; set; } = "There are no humans in the current room to gas.";
    }
}