namespace Assets.Source.Twitch
{
    using Assets.Source.Twitch.Listeners;

    public interface ITwitchHandler
    {
        void RegisterCommandListener(ITwitchCommandListener listener);

        void UnregisterCommandListener(ITwitchCommandListener listener);

        void RegisterMessageListener(ITwitchMessageListener listener);

        void UnregisterMessageListener(ITwitchMessageListener listener);
    }
}