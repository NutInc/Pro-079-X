namespace Pro079XBlackout
{
    using System;
    using System.Collections.Generic;
    using MEC;
    using CommandSystem;
    using Exiled.API.Features;
    using Pro079X.Interfaces;

    public class BlackoutCommand : IUltimate079
    {
        public string Command { get; } = Pro079XBlackout.Singleton.Translation.Command;
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = Pro079XBlackout.Singleton?.Translation.Description;
        public int Cooldown { get; } = Pro079XBlackout.Singleton.Config.Cooldown;
        public int Cost { get; } = Pro079XBlackout.Singleton.Config.Cost;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Timing.RunCoroutine(RunUltimate());
            response = Pro079X.Pro079X.Singleton?.Translation.Command;
            return true;
        }

        private static IEnumerator<float> RunUltimate()
        {
            Cassie.Message(Pro079XBlackout.Singleton.Config.BlackoutCassieMessage);
            yield return Timing.WaitForSeconds(12.1f);
            Map.TurnOffAllLights(Pro079XBlackout.Singleton.Config.BlackoutDuration);
        }
    }
}