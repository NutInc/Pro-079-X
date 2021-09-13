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
        public string Command => "079";
        public string[] Aliases => Array.Empty<string>();
        public string Description => "Base command handler for Pro079";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get((sender as CommandSender)?.SenderId);
            if (!ply.IsScp079())
            {
                response = Pro079X.Singleton.Translations.NotScp079;
                return false;
            }

            response = Methods.GetHelp();
            if (arguments.Count == 0)
                return false;

            ICommand079 command = Methods.GetCommand(arguments.At(0));
            if (command != null)
            {
                if (Pro079X.Singleton.Config.EnableCassieCooldown && ply.OnCassieCooldown())
                {
                    response = Pro079X.Singleton.Translations.CassieOnCooldown;
                    return false;
                }

                if (ply.OnCommandCooldown(command))
                {
                    response = Pro079X.Singleton.Translations.Cooldown;
                    return false;
                }

                if (!ply.IsBypassModeEnabled)
                {
                    if (command.Cost > ply.Energy)
                    {
                        response = Pro079X.Singleton.Translations.LowEnergy;
                        return false;
                    }

                    if (command.MinLevel > ply.Level)
                    {
                        response = Pro079X.Singleton.Translations.LowLevel;
                        return false;
                    }
                }

                bool success = command.Execute(arguments, sender, out response);
                if (!success)
                    return false;

                Manager.CoroutineHandles.Add(Timing.RunCoroutine(Manager.SetOnCooldown(ply, command)));
                if (Pro079X.Singleton.Config.EnableCassieCooldown)
                    Manager.CassieCooldowns[ply] =
                        DateTime.Now + TimeSpan.FromSeconds(Pro079X.Singleton.Config.CassieCooldown);
                if (!ply.IsBypassModeEnabled)
                    ply.Energy -= command.Cost;

                return true;
            }

            if (arguments.At(0) == Pro079X.Singleton.Translations.UltCmd)
            {
                if (arguments.Count < 2)
                {
                    response = Methods.FormatUltimates();
                    return true;
                }

                IUltimate079 ultimate = Methods.GetUltimate(arguments.At(1));
                if (ultimate == null)
                    return true;

                if (ply.OnUltimateCooldown())
                {
                    response = Pro079X.Singleton.Translations.Cooldown;
                    return false;
                }

                if (!ply.IsBypassModeEnabled)
                {
                    if (ply.Energy < ultimate.Cost)
                    {
                        response = Pro079X.Singleton.Translations.LowEnergy;
                        return false;
                    }

                    if (ply.Level < Pro079X.Singleton.Config.UltimateLevel)
                    {
                        response = Pro079X.Singleton.Translations.LowLevel;
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