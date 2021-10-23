using Exiled.API.Enums;
using Interactables.Interobjects.DoorUtils;

namespace Pro079XGenerators
{
    using CommandSystem;
    using Pro079X.Interfaces;
    using Exiled.API.Features;
    using MEC;
    using System;
    using System.Collections.Generic;
    
    public class GeneratorCommand : ICommand079
    {
        public string Command { get; } = Pro079XGenerators.Singleton.Translations.Command;
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = Pro079XGenerators.Singleton.Translations.Description;
        public string ExtraArguments { get; } = string.Empty;
        public bool Cassie { get; } = true;
        public int Cooldown { get; } = Pro079XGenerators.Singleton.Config.Cooldown;
        public int MinLevel { get; } = Pro079XGenerators.Singleton.Config.Level;
        public int Cost { get; } = Pro079XGenerators.Singleton.Config.Cost;
        public string CommandReady { get; } = Pro079XGenerators.Singleton.Translations.CommandReady;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Timing.RunCoroutine(Fake5Gens());
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }
        private static IEnumerator<float> Fake5Gens()
        {
            // People complained about it being "easy to be told apart". Not anymore.
            NineTailedFoxAnnouncer annc = NineTailedFoxAnnouncer.singleton;
            while (annc.queue.Count > 0 || AlphaWarheadController.Host.inProgress)
            {
                yield return Timing.WaitForSeconds(0f);
            }

            Respawning.RespawnEffectsController.PlayCassieAnnouncement("SCP079RECON5", false, true);
            // This massive for loop jank is what the main game does. Go complain to them.
            for (int i = 0; i < 2750; i++)
            {
                yield return Timing.WaitForSeconds(0f);
            }

            while (annc.queue.Count > 0 || AlphaWarheadController.Host.inProgress)
            {
                yield return Timing.WaitForSeconds(0f);
            }
            
            MapUtils.TurnOffAllLights(10);
            MapUtils.LockAllDoors();

            yield return Timing.WaitForSeconds(10);
            
            MapUtils.UnlockAllDoors();
            
            Respawning.RespawnEffectsController.PlayCassieAnnouncement("SCP079RECON6", false, true);
            Respawning.RespawnEffectsController.PlayCassieAnnouncement("SCP 0 7 9 CONTAINEDSUCCESSFULLY", false, false);
            
        }
    }
}