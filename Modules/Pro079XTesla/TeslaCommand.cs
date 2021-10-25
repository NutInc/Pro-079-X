using System;
using System.Collections.Generic;
using CommandSystem;
using Exiled.API.Features;
using MEC;
using Pro079X.Interfaces;
using Pro079X.Logic;

namespace Pro079XTesla
{
    public class TeslaCommand : ICommand079
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Pro079XTesla.Singleton.IsActive)
            {
                response = Pro079XTesla.Singleton.Translations.OnCooldown.ReplaceAfterToken('$', new[]
                {
                    new Tuple<string, object>("time", _secondsRemaining)
                });
                return false;
            }

            if (arguments.Count < 2 || !int.TryParse(arguments.At(1), out int seconds))
            {
                response = Pro079XTesla.Singleton.Translations.Usage;
                return false;
            }

            _plySender = Player.Get((sender as CommandSender)?.SenderId);

            Pro079XTesla.Singleton.CoroutineHandle = Timing.RunCoroutine(TeslaCountdown(seconds));
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }

        public string Command => Pro079XTesla.Singleton.Translations.Command;
        public string[] Aliases => Array.Empty<string>();
        public string Description => Pro079XTesla.Singleton.Translations.Description;

        public string ExtraArguments => string.Empty;
        public bool Cassie => false;
        public int Cooldown => Pro079XTesla.Singleton.Config.Cooldown;
        public int MinLevel => Pro079XTesla.Singleton.Config.Level;
        public int Cost => Pro079XTesla.Singleton.Config.Cost;
        public string CommandReady => Pro079XTesla.Singleton.Translations.CommandReady;

        private Player _plySender;
        private int _secondsRemaining;

        private IEnumerator<float> TeslaCountdown(int seconds)
        {
            Pro079XTesla.Singleton.IsActive = true;
            _secondsRemaining = seconds;
            for (int i = 0; i < seconds; i++)
            {
                if (Pro079XTesla.Singleton.Config.GrantExperience)
                    _plySender.Experience++;

                _secondsRemaining--;
                yield return 0f;
            }

            Pro079XTesla.Singleton.IsActive = false;
        }
    }
}