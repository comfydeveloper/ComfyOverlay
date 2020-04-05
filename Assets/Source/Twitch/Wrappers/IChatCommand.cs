namespace Assets.Source.Twitch.Wrappers
{
    using System.Collections.Generic;

    public interface IChatCommand
    {
        string CommandText { get; }

        List<string> ArgumentsAsList { get; }

        string ArgumentsAsString { get; }

        IChatMessage ChatMessage { get; }

        bool IsBroadcaster { get; }

        bool IsModerator { get; }
    }
}