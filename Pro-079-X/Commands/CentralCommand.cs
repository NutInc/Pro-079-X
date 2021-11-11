using System.Collections.Generic;
using System.Linq;

namespace Pro079X.Commands
{
    using Interfaces;
    using CommandSystem;
    using Exiled.API.Features;
    using Logic;
    using MEC;
    using System;
    
    [CommandHandler(typeof(ClientCommandHandler))]
    public class CentralCommand : ICommand
    {
        public string Command { get; } = "079";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Base command handler for Pro079";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);

            if (!ply.IsScp079())
            {
                response = Pro079X.Singleton?.Translation.NotScp079;
                return false;
            }
                                                
            if (Pro079X.Singleton.Config.BlacklistedIds.Contains(ply.UserId))
            {
                response = "Skill issue";
                ply.Kill();
                Map.Broadcast((ushort)5f,$"{ply.Nickname} has a major skill issue as SCP-079.");
                Cassie.Message("SCP 0 7 9 CONTAINEDSUCCESSFULLY CONTAINMENTUNIT P P");
                return false;
            }
            
            response = Methods.GetHelp();
            if (arguments.Count == 0)
            {
                return false;
            }
            
            ICommand079 command = null;

            if (Methods.CommandExists(arguments.At(0)))
            {
                command = Methods.GetCommand(arguments.At(0));
            }
                

            if (command != null)
            {
                if (Pro079X.Singleton.Config.EnableCassieCooldown && ply.OnCassieCooldown())
                {
                    response = Methods.OnCooldownString(Pro079X.Singleton.Translation.CassieOnCooldown,
                        Manager.CassieCooldowns[ply].Second - (DateTime.Now.Second - Manager.CassieCooldowns[ply].Second));
                    return false;
                }

                if (ply.OnCommandCooldown(command))
                {
                    response = Pro079X.Singleton?.Translation.Cooldown;
                    return false;
                }

                if (!ply.IsBypassModeEnabled)
                {
                    if (command.Cost > ply.Energy)
                    {
                        response = Methods.LowApString(Pro079X.Singleton.Translation.LowEnergy, command.Cost);
                        return false;
                    }

                    if (command.MinLevel > ply.Level)
                    {
                        Log.Debug($"Current Level: {ply.Level}");
                        Log.Debug($"Required Level: {command.MinLevel}");
                        response = Methods.LowLevelString(Pro079X.Singleton.Translation.LowLevel, command.MinLevel);
                        return false;
                    }
                }

                bool success = command.Execute(arguments, sender, out response);
                if (!success)
                    return false;

                Manager.CoroutineHandles.Add(Timing.RunCoroutine(Manager.SetOnCooldown(ply, command)));
                if (Pro079X.Singleton.Config.EnableCassieCooldown && command.Cassie)
                    Manager.CassieCooldowns[ply] =
                        DateTime.Now + TimeSpan.FromSeconds(Pro079X.Singleton.Config.CassieCooldown);
                if (!ply.IsBypassModeEnabled)
                    ply.Energy -= command.Cost;

                return true;
            }

            if (arguments.At(0) == Pro079X.Singleton?.Translation.UltCmd)
            {
                if (arguments.Count < 2)
                {
                    response = Methods.FormatUltimates();
                    return true;
                }

                IUltimate079 ultimate = null;

                if (Methods.UltimateExists(arguments.At(1)))
                {
                    ultimate = Methods.GetUltimate(arguments.At(1));
                }
                
                if (ultimate == null)
                {
                    return true;
                }
                
                if (ply.OnUltimateCooldown())
                {
                    response = Methods.OnCooldownString(Pro079X.Singleton.Translation.UltDown,
                        Manager.UltimateCooldowns[ply].Second - (DateTime.Now.Second - Manager.UltimateCooldowns[ply].Second));
                    return false;
                }

                if (!ply.IsBypassModeEnabled)
                {
                    if (ply.Energy < ultimate.Cost)
                    {
                        response = Methods.LowApString(Pro079X.Singleton?.Translation.LowEnergy, (int)ply.Energy);
                        return false;
                    }

                    if (ply.Level < Pro079X.Singleton.Config.UltimateLevel)
                    {
                        response = Methods.LowLevelString(Pro079X.Singleton.Translation.UltLocked, Pro079X.Singleton.Config.UltimateLevel);
                        return false;
                    }
                }
                
                bool success = ultimate.Execute(arguments, sender, out response);

                if (!success)
                    return false;

                Manager.UltimateCooldowns[ply] = DateTime.Now + TimeSpan.FromSeconds(ultimate.Cooldown);
                if (!ply.IsBypassModeEnabled)
                    ply.Energy -= ultimate.Cost;

                return true;
            }

            return true;
        }
    }
}