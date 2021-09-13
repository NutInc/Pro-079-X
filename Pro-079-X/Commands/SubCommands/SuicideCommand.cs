﻿namespace Pro079X.Commands
{
    using Interfaces;
    using CommandSystem;
    using Exiled.API.Features;
    using Logic;
    using System;

    public class SuicideCommand : ICommand079
    {
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

        public string ExtraArguments { get; }
        public bool Cassie { get; }
        public int Cooldown { get; }
        public int MinLevel { get; }
        public int Cost { get; }
        public string CommandReady { get; }
    }
}