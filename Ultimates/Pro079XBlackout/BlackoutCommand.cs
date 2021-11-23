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
        public string Command => Pro079XBlackout.Singleton.Translation.Command;
        public string[] Aliases => Array.Empty<string>();
        public string Description => Pro079XBlackout.Singleton?.Translation.Description;
        public int Cooldown => Pro079XBlackout.Singleton.Config.Cooldown;
        public int Cost => Pro079XBlackout.Singleton.Config.Cost;
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Log.Debug("Execute() invoked for blackout!");
            Timing.RunCoroutine(RunUltimate());
            response = Pro079X.Pro079X.Singleton?.Translation.Command;
            return true;
        }

        private static IEnumerator<float> RunUltimate()
        {
            Log.Debug("Running ultimate coroutine for Blackout!");
            Cassie.Message(Pro079XBlackout.Singleton.Config.BlackoutCassieMessage);
            yield return Timing.WaitForSeconds(12.1f);
            Map.TurnOffAllLights(Pro079XBlackout.Singleton.Config.BlackoutDuration);
        }
    }
}