namespace Assets.Source.Modes.Shared
{
    using Assets.Source.Twitch.Listeners;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public abstract class CommandListenerMonoBehavior : MonoBehaviour, ITwitchCommandListener
    {
        public void OnCommandReceived(IChatCommand chatCommand)
        {
            if (this.IsActive() && this.CanHandle(chatCommand))
            {
                Handle(chatCommand);
            }
        }

        private bool IsActive()
        {
            return this.gameObject.activeSelf;
        }

        protected abstract bool CanHandle(IChatCommand chatCommand);

        protected abstract void Handle(IChatCommand chatCommand);
    }
}