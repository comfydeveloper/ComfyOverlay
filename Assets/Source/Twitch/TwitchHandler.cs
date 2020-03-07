namespace Assets.Source.Twitch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Source.Twitch.Listeners;
    using Assets.Source.Twitch.Wrappers;

    using TwitchLib.Client.Events;
    using TwitchLib.Client.Models;
    using TwitchLib.Unity;

    using UnityEngine;

    public class TwitchHandler : MonoBehaviour, ITwitchHandler
    {
        private readonly List<ITwitchCommandListener> commandListeners = new List<ITwitchCommandListener>();
        private readonly List<ITwitchMessageListener> messageListeners = new List<ITwitchMessageListener>();

        private Client client;

        public void Start()
        {
            Application.runInBackground = true;
            this.RegisterListeners();

            ConnectionCredentials credentials = CreateCredentials();
            this.client = new Client();

            this.client.Initialize(credentials, PlayerPrefs.GetString("channel"));
            this.client.OnChatCommandReceived += this.OnChatCommandReceived;
            this.client.OnMessageReceived += this.OnMessageReceived;

            this.client.Connect();
        }

        private static ConnectionCredentials CreateCredentials()
        {
            ConnectionCredentials credentials = new ConnectionCredentials(PlayerPrefs.GetString("user"), PlayerPrefs.GetString("oauth"));
            return credentials;
        }

        private void RegisterListeners()
        {
            this.commandListeners.AddRange(FindListenersOfType<ITwitchCommandListener>());
            this.messageListeners.AddRange(FindListenersOfType<ITwitchMessageListener>());
        }

        private void OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            IChatMessage chatMessage = e.ChatMessage.Wrap();

            foreach (ITwitchMessageListener listener in this.messageListeners)
            {
                listener.OnMessageReceived(chatMessage);
            }
        }

        private void OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            IChatCommand chatCommand = e.Command.Wrap();

            foreach (ITwitchCommandListener listener in this.commandListeners)
            {
                listener.OnCommandReceived(chatCommand);
            }
        }

        private static IEnumerable<T> FindListenersOfType<T>()
        {
            return FindObjectsOfType<MonoBehaviour>().OfType<T>();
        }

        public void RegisterCommandListener(ITwitchCommandListener listener)
        {
            this.commandListeners.Add(listener);
        }

        public void UnregisterCommandListener(ITwitchCommandListener listener)
        {
            this.commandListeners.Remove(listener);
        }

        public void RegisterMessageListener(ITwitchMessageListener listener)
        {
            this.messageListeners.Add(listener);
        }

        public void UnregisterMessageListener(ITwitchMessageListener listener)
        {
            this.messageListeners.Remove(listener);
        }
    }
}