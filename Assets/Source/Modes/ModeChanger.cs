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
        private bool isLocked;

        public void Start()
        {
            this.modes = FindObjectsOfType<MonoBehaviour>().OfType<IOverlayMode>().ToList();
        }

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("mode") && chatCommand.HasParameters()
                   || chatCommand.Is("stop") && chatCommand.IsFromStaff()
                   || chatCommand.Is("lock") && chatCommand.IsFromStaff()
                   || chatCommand.Is("unlock") && chatCommand.IsFromStaff();
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            if (!this.isLocked && chatCommand.Is("mode"))
            {
                this.ChangeMode(chatCommand);
            }

            if (chatCommand.Is("stop"))
            {
                this.StopCurrentMode();
            }

            if (chatCommand.Is("lock"))
            {
                this.isLocked = true;
            }

            if (chatCommand.Is("unlock"))
            {
                this.isLocked = false;
            }
        }

        private void StopCurrentMode()
        {
            this.activeMode?.Disable();
            this.activeMode = null;
        }

        private void ChangeMode(IChatCommand chatCommand)
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
    }
}