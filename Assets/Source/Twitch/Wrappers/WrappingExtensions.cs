namespace Assets.Source.Twitch.Wrappers
{
    using TwitchLib.Client.Models;

    public static class WrappingExtensions
    {
        public static IChatCommand Wrap(this ChatCommand command)
        {
            return new ChatCommandWrapper(command);
        }

        public static IChatMessage Wrap(this ChatMessage message)
        {
            return new ChatMessageWrapper(message);
        }
    }
}