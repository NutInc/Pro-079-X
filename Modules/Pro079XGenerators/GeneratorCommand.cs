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
            Exiled.API.Features.Cassie.Message("OVERCHARGING IN . 3 . 2 . 1");
            yield return Timing.WaitForSeconds(Exiled.API.Features.Cassie.CalculateDuration("OVERCHARGING IN . 3 . 2 . 1"));
            MapUtils.LockAllDoors();
            MapUtils.TurnOffAllLights(7);
            yield return Timing.WaitForSeconds(5);
            Exiled.API.Features.Cassie.Message("SCP 0 7 9 CONTAINED SUCCESSFULLY. ");
            yield return Timing.WaitForSeconds(Exiled.API.Features.Cassie.CalculateDuration("SCP 0 7 9 CONTAINED SUCCESSFULLY. "));
            MapUtils.UnlockAllDoors();
        }
    }
}