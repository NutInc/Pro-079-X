using Exiled.API.Interfaces;

namespace Pro079XMtf.Configs
{
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "mtf";
        public string CommandReady { get; set; } = "<b>Mtf command ready</b>";
        public string Description { get; set; } = "Fakes a Mtf spawn announcement.";

        public string Usage { get; set; } = ".079 mtf p 5 4 -> Announces Papa-5 is coming and there are 4 SCP remaining";
    }
}