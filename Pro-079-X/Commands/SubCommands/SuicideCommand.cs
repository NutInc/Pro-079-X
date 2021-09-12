using Pro079X.Interfaces;
using CommandSystem;
using Exiled.API.Features;
using Pro079X.Logic;
using System;

namespace Pro079X.Commands.SubCommands
{
    public class SuicideCommand : ICommand079
    {
        public string ExtraArguments { get; }
        public bool Cassie { get; }
        public int Cooldown { get; }
        public int MinLevel { get; }
        public int Cost { get; }
        public string CommandReady { get; }
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            if (Manager.CanSuicide)
            {
                ply.Kill(DamageTypes.Recontainment);
                response = Pro079X.Singleton.Translations.Success;
                return true;
            }

            response = Pro079X.Singleton.Translations.CantSuicide;
            return false;
        }

        public string Command => Pro079X.Singleton.Translations.SuicideCmd;
        public string[] Aliases => Array.Empty<string>();
        public string Description => Pro079X.Singleton.Translations.SuicideHelp;
    }
}