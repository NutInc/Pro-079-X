using System;
using Exiled.API.Features;
using Pro079X.Logic;
using Pro079XInfo.Configs;

namespace Pro079XInfo
{
    public class Pro079XInfo : Plugin<Config, Translations>
    {
        private InfoCommand _infoCommand;
        internal static Pro079XInfo Singleton;
        internal Translations Translations;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            _infoCommand = new InfoCommand();
            //Exiled.Events.Handlers.Server.RespawningTeam += _infoCommand.OnRespawningTeam;
            Manager.RegisterCommand(_infoCommand);

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            //Exiled.Events.Handlers.Server.RespawningTeam -= _infoCommand.OnRespawningTeam;
            _infoCommand = null;
            Singleton = null;
            Translations = null;
            base.OnDisabled();
        }

        public override string Author => "Build";
        public override Version Version => new Version(4, 0, 0);
    }
}