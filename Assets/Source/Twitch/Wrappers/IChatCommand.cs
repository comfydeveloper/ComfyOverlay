namespace Assets.Source.Twitch.Wrappers
{
    using System.Collections.Generic;

    public interface IChatCommand
    {
        string CommandText { get; }

        List<string> ArgumentsAsList { get; }

        IChatMessage ChatMessage { get; }
    }
}