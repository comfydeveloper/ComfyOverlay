using TwitchLib.Client.Models;

namespace Assets.Source.Twitch.Wrappers
{
    public class ChatMessageWrapper : IChatMessage
    {
        private readonly ChatMessage chatMessage;

        public ChatMessageWrapper(ChatMessage chatMessage)
        {
            this.chatMessage = chatMessage;
        }

        public string Username { get { return this.chatMessage.Username; } }
    }
}