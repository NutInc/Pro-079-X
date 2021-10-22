using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using Pro079X.Interfaces;

namespace Pro079XTeleport
{
    public class TeleportCommand : ICommand079
    {
        public string Command { get; } = Pro079XTeleport.Singleton.Translations.Command;
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = Pro079XTeleport.Singleton.Translations.Description;
        public string ExtraArguments { get; } = string.Empty;
        public bool Cassie { get; } = false;
        public int Cooldown { get; } = Pro079XTeleport.Singleton.Config.Cooldown;
        public int MinLevel { get; } = Pro079XTeleport.Singleton.Config.Level;
        public int Cost { get; } = Pro079XTeleport.Singleton.Config.Cost;
        public string CommandReady { get; } = Pro079XTeleport.Singleton.Translations.CommandReady;
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = Pro079XTeleport.Singleton.Translations.Usage;
                return false;
            }

            RoleType role = GetRole(arguments.At(0));

            if (role == RoleType.None)
            {
                response = Pro079XTeleport.Singleton.Translations.InvalidRoleMessage;
                return false;
            }

            Camera079 cam = GetCamera(role);
            if (cam == null)
            {
                response = Pro079XTeleport.Singleton.Translations.ScpNotInGameMessage;
                return false;
            }
            
            Player.Get((sender as CommandSender)?.SenderId)?.ReferenceHub.scp079PlayerScript.CmdSwitchCamera(cam.cameraId, false);
            response = Pro079X.Pro079X.Singleton.Translation.Success;
            return true;
        }

        private RoleType GetRole(string role)
        {
            if (role.Contains("096"))
            {
                return RoleType.Scp096;
            }

            if (role.Contains("173"))
            {
                return RoleType.Scp173;
            }

            if (role.Contains("049"))
            {
                return RoleType.Scp049;
            }

            if (role.Contains("939"))
            {
                if (role.Contains("-"))
                {
                    int index = role.IndexOf("-") > 0 ? role.IndexOf("-") - 1 : 0;
                    string scp939 = role.Substring(index);
                    if (scp939.Contains("89"))
                    {
                        return RoleType.Scp93989;
                    }
                    if(scp939.Contains("53"))
                    {
                        return RoleType.Scp93953;
                    }
                }
            }

            return RoleType.None;
        }

        private Camera079 GetCamera(RoleType role)
        {
            List<Player> scps = Player.List.Where(player => player.Role == role).ToList();
            List<Camera079> cameras = scps[0].CurrentRoom.Cameras.ToList();
            return cameras[0];
        }
    }
}