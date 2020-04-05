namespace Assets.Source.Modes.Garden
{
    using System.Collections.Generic;

    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public class PotatoSpawner : CommandListenerMonoBehavior
    {
        [SerializeField]
        private GameObject potatoPrefab;

        private readonly List<GameObject> potatoes = new List<GameObject>();

        private readonly List<string> registeredUsers = new List<string>();

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("join") && !this.registeredUsers.Contains(chatCommand.ChatMessage.Username);
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            this.SpawnPotato(chatCommand);
            this.RegisterUser(chatCommand);
        }

        private void RegisterUser(IChatCommand chatCommand)
        {
            this.registeredUsers.Add(chatCommand.ChatMessage.Username);
        }

        private void SpawnPotato(IChatCommand chatCommand)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();

            GameObject potato = Instantiate(this.potatoPrefab, spawnPosition, Quaternion.identity);
            potato.GetComponent<PotatoController>().SetName(chatCommand.ChatMessage.Username);
            potato.GetComponent<PotatoDialogController>().UserName = chatCommand.ChatMessage.Username;
            this.potatoes.Add(potato);
        }

        private static Vector2 GetRandomSpawnPosition()
        {
            Vector3 viewportBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 viewportTopRight = Camera.main.ViewportToWorldPoint(Vector3.one);
            float randomX = Random.Range(viewportBottomLeft.x + 2f, viewportTopRight.x - 2f);
            Vector2 spawnPosition = new Vector2(randomX, viewportBottomLeft.y + 0.3f);
            return spawnPosition;
        }

        public void OnDisable()
        {
            foreach (GameObject potato in this.potatoes)
            {
                Destroy(potato);
            }

            this.potatoes.Clear();
            this.registeredUsers.Clear();
        }
    }
}