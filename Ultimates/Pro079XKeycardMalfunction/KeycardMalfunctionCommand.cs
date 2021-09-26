

namespace Pro079XKeycardMalfunction
{
    using Pro079X.Interfaces;
    using CommandSystem;
    using System;
    using Exiled.API.Features;
    using MEC;
    public class KeycardMalfunctionCommand : IUltimate079
    {
        public string Command { get; } = Pro079XKeycardMalfunction.Singleton.Translation.Command;
        
        public string Description { get; } = Pro079XKeycardMalfunction.Singleton.Translation.Description;
        public int Cooldown { get; } = Pro079XKeycardMalfunction.Singleton.Config.Cooldown;
        public int Cost { get; } = Pro079XKeycardMalfunction.Singleton.Config.Cost;
        
        public string[] Aliases { get; }
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (EventHandlers.KeycardsBroken)
            {
                response = "Keycard Malfunction already occuring!";
                return false;
            }

            EventHandlers.KeycardsBroken = true;
            Cassie.Message(Pro079XKeycardMalfunction.Singleton
                .Translation.CassieStartMessage);
            Timing.CallDelayed(Pro079XKeycardMalfunction.Singleton.Config.Duration,()=>
            {
                EventHandlers.KeycardsBroken = false;
                Cassie.Message(Pro079XKeycardMalfunction.Singleton
                    .Translation.CassieEndMessage);
            });

            response = "We do some trolling";
            return true;
        }
    }
}