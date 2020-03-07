namespace Assets.Source.Twitch.Extensions
{
    using System.Linq;

    using Assets.Source.Twitch.Wrappers;

    public static class ChatCommandExtensions
    {
        public static bool HasParameters(this IChatCommand command)
        {
            return command.ArgumentsAsList.Any();
        }

        public static bool Is(this IChatCommand command, string commandText)
        {
            return command.CommandText.ToLower() == commandText;
        }
    }
}