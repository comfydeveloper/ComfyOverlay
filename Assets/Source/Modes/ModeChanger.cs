namespace Assets.Source.Modes
{
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public class ModeChanger : CommandListenerMonoBehavior
    {
        private List<IOverlayMode> modes;

        private IOverlayMode activeMode;

        public void Start()
        {
            this.modes = FindObjectsOfType<MonoBehaviour>().OfType<IOverlayMode>().ToList();
        }

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("mode") && chatCommand.HasParameters()
                   || (chatCommand.Is("stop") && chatCommand.IsBroadcaster || chatCommand.IsModerator);
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            if (chatCommand.Is("mode"))
            {
                string modeName = chatCommand.ArgumentsAsList[0];
                IOverlayMode mode = this.modes.FirstOrDefault(m => m.Is(modeName));

                if (mode != null)
                {
                    this.activeMode?.Disable();
                    this.activeMode = mode;
                    mode.Enable();
                }
            }

            if (chatCommand.Is("stop"))
            {
                this.activeMode?.Disable();
                this.activeMode = null;
            }
        }
    }
}