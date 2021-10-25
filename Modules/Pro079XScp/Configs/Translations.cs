using Exiled.API.Interfaces;

namespace Pro079XScp.Configs
{
    public class Translations : ITranslation
    {
        public string Command { get; set; } = "scp";
        public string CommandReady { get; set; } = "<b>Scp command ready</b>";
        public string Description { get; set; } = "Fakes the specified Scp's death.";

        public string Usage { get; set; } =
            "Usage: .079 scp (173/096/106/049/939) (classd/sci/tesla/chaos/mtf/decont) - $min AP";

        public string NoMtfLeft { get; set; } = "No MTF alive. Please select another death type.";
        public string IncorrectMethodName { get; set; } = "Type a method that exists";
    }
}