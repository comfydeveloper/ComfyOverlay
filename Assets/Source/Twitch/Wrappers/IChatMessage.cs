namespace Assets.Source.Twitch.Wrappers
{
    public interface IChatMessage
    {
        string Username { get; }

        bool IsBroadcaster { get; }

        bool IsModerator { get; }
    }
}