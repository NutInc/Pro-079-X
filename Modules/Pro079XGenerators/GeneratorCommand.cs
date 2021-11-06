using Exiled.API.Enums;
using Interactables.Interobjects.DoorUtils;
using UnityEngine;

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
        public string Command => Pro079XGenerators.Singleton.Translations.Command;
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description => Pro079XGenerators.Singleton.Translations.Description;
        public string ExtraArguments { get; } = string.Empty;
        public bool Cassie { get; } = true;
        public int Cooldown => Pro079XGenerators.Singleton.Config.Cooldown;
        public int MinLevel => Pro079XGenerators.Singleton.Config.Level;
        public int Cost => Pro079XGenerators.Singleton.Config.Cost;
        public string CommandReady => Pro079XGenerators.Singleton.Translations.CommandReady;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Timing.RunCoroutine(Fake5Gens());
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }
        private static IEnumerator<float> Fake5Gens()
        {
            Exiled.API.Features.Cassie.Message("OVERCHARGING IN . 3 . 2 . 1");
            for (int i = 0; i < Application.targetFrameRate * Exiled.API.Features.Cassie.CalculateDuration("OVERCHARGING IN . 3 . 2 . 1") + 4; i++)
            {
                yield return 0f;
            }
            MapUtils.LockAllDoors();
            MapUtils.TurnOffAllLights(7);
            yield return Timing.WaitForSeconds(5);
            MapUtils.UnlockAllDoors();
            Exiled.API.Features.Cassie.Message("SCP 0 7 9 CONTAINED SUCCESSFULLY.");
        }
    }
}