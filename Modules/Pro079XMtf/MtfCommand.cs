using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Pro079X.Interfaces;

namespace Pro079XMtf
{
    public class MtfCommand : ICommand079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "USAGE";
            if (arguments.Count < 4)
                return false;

            if (!int.TryParse(arguments.At(3), out int scpLeft) || !int.TryParse(arguments.At(2), out int mtfNum) ||
                !char.IsLetter(arguments.At(0)[0]))
                return false;

            if (scpLeft > Pro079XMtf.Singleton.Config.MaxScp)
            {
                response = "";
                return false;
            }

            Exiled.API.Features.Cassie.Message(
                "MtfUnit epsilon 11 designated nato_" + arguments.At(0)[0] + " " + mtfNum + " " +
                "HasEntered AllRemaining AwaitingRecontainment" + " " + scpLeft + " " + "scpsubjects");
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }

        public string Command => Pro079XMtf.Singleton.Translations.Command;
        public string[] Aliases => Array.Empty<string>();
        public string Description => Pro079XMtf.Singleton.Translations.Description;
        public string ExtraArguments => string.Empty;
        public bool Cassie => true;
        public int Cooldown => Pro079XMtf.Singleton.Config.Cooldown;
        public int MinLevel => Pro079XMtf.Singleton.Config.Level;
        public int Cost => Pro079XMtf.Singleton.Config.Cost;
        public string CommandReady => Pro079XMtf.Singleton.Translations.CommandReady;
    }
}