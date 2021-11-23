using System;
using CommandSystem;
using Exiled.API.Features;
using MEC;
using Pro079X.Interfaces;

namespace Pro079XKeycardMalfunction
{
    public class KeymalCommand : IUltimate079
    {
        
        public string Command => Pro079XKeycardMalfunction.Singleton.Translation.Command;
        
        public string Description => Pro079XKeycardMalfunction.Singleton.Translation.Description;
        public int Cooldown => Pro079XKeycardMalfunction.Singleton.Config.Cooldown;
        public int Cost => Pro079XKeycardMalfunction.Singleton.Config.Cost;
        
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