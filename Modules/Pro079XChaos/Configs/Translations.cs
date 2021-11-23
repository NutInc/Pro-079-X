using Exiled.API.Interfaces;

namespace Pro079XChaos.Configs
{
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "chaos";
        public string Description { get; set; } = "Fakes the chaos announcement";
        public string Usage { get; set; }
        public string CommandReady { get; set; } = "<b><color=\"green\">Chaos command ready</color></b>";
    }
}