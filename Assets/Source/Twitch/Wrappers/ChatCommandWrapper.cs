namespace Assets.Source.Twitch.Wrappers
{
    using System.Collections.Generic;

    using TwitchLib.Client.Models;

    public class ChatCommandWrapper : IChatCommand
    {
        private readonly ChatCommand chatCommand;

        private IChatMessage message;

        public ChatCommandWrapper(ChatCommand chatCommand)
        {
            this.chatCommand = chatCommand;
        }

        public string CommandText { get { return this.chatCommand.CommandText; } }

        public List<string> ArgumentsAsList { get { return this.chatCommand.ArgumentsAsList; }}

        public IChatMessage ChatMessage
        {
            get
            {
                return message ?? (this.message = this.chatCommand.ChatMessage.Wrap());
            }
        }
    }
}