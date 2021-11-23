using System;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Pro079X.Interfaces;

namespace Pro079XScp
{
    public class ScpCommand: ICommand079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Pro079XScp.Singleton.Translations.Usage;
            if (arguments.Count < 3)
                return false;


            if (!Pro079XScp.Singleton.Config.ScpList.Contains(arguments.At(1)))
                return false;
            
            string scpNum = string.Join(" ", arguments.At(1).ToCharArray());
            string broadcast = "scp " + scpNum;

            switch (arguments.At(2))
            {
                case "mtf":
                    Player dummy = Player.List.FirstOrDefault(player => player.Team == Team.MTF);
                    if (dummy == null)
                    {
                        response = Pro079XScp.Singleton.Translations.NoMtfLeft;
                        return false;
                    }

                    if (!Respawning.NamingRules.UnitNamingRules.TryGetNamingRule(
                        Respawning.SpawnableTeamType.NineTailedFox,
                        out Respawning.NamingRules.UnitNamingRule unitNamingRule))
                        broadcast += " Unknown";
                    else
                        broadcast += " CONTAINEDSUCCESSFULLY CONTAINMENTUNIT " +
                                     unitNamingRule.GetCassieUnitName(dummy.ReferenceHub.characterClassManager
                                         .CurUnitName);

                    break;
                case "classd":
                    broadcast += " terminated by ClassD personnel";
                    break;
                case "sci":
                case "scientist":
                    broadcast += " terminated by science personnel";
                    break;
                case "chaos":
                    broadcast += " terminated by ChaosInsurgency";
                    break;
                case "tesla":
                    broadcast += " Successfully Terminated by automatic security system";
                    break;
                case "decont":
                    broadcast += " Lost in Decontamination Sequence";
                    break;
                default:
                    response = Pro079XScp.Singleton.Translations.IncorrectMethodName + " .079 scp " + arguments.At(1) +
                               " (classd/sci/chaos/tesla/mtf/decont)";
                    return false;
            }

            Exiled.API.Features.Cassie.Message(broadcast);
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }

        public string Command => Pro079XScp.Singleton.Translations.Command;
        public string[] Aliases => Array.Empty<string>();
        public string Description => Pro079XScp.Singleton.Translations.Description;

        public string ExtraArguments => string.Empty;
        public bool Cassie => true;
        public int Cooldown => Pro079XScp.Singleton.Config.Cooldown;
        public int MinLevel => Pro079XScp.Singleton.Config.Level;
        public int Cost => Pro079XScp.Singleton.Config.Cost;
        public string CommandReady => Pro079XScp.Singleton.Translations.CommandReady;
    }
}