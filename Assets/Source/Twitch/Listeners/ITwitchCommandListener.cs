namespace Assets.Source.Twitch.Listeners
{
    using Assets.Source.Twitch.Wrappers;

    /// <summary>
    /// Implement this interface on a MonoBehaviour object and it will automatically receive incoming chat commands
    /// if the <see cref="ITwitchHandler"/> is up and running.
    /// </summary>
    public interface ITwitchCommandListener
    {
        void OnCommandReceived(IChatCommand chatCommand);
    }
}