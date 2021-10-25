﻿using Exiled.API.Features;
using MEC;
using Pro079X.Logic;
using System;
using Pro079XTesla.Configs;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace Pro079XTesla
{
    public class Pro079XTesla : Plugin<Config, Translations>
    {
        private EventHandlers _eventHandlers;
        internal static Pro079XTesla Singleton;
        internal Translations Translations;
        internal bool IsActive;
        internal CoroutineHandle CoroutineHandle;

        public override void OnEnabled()
        {
            Singleton = this;
            Translations = new Translations();
            _eventHandlers = new EventHandlers();
            PlayerEvents.TriggeringTesla += _eventHandlers.OnTriggeringTesla;
            if (!Manager.RegisterCommand(new TeslaCommand()))
                OnDisabled();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerEvents.TriggeringTesla -= _eventHandlers.OnTriggeringTesla;
            Timing.KillCoroutines(CoroutineHandle);
            _eventHandlers = null;
            Translations = null;
            Singleton = null;
            base.OnDisabled();
        }

        public override string Author => "Build";
        public override Version Version => new Version(4, 0, 0);
    }
}