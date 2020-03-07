﻿namespace Assets.Source.Modes.Hat
{
    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using Boo.Lang;

    using UnityEngine;
    using UnityEngine.U2D;

    public class UmbrellaSpawner : CommandListenerMonoBehavior
    {
        public GameObject UmbrellaPrefab;
        private Vector3 cameraUpperRight;
        private Vector3 cameraBottomLeft;
        private readonly List<GameObject> umbrellas = new List<GameObject>();

        public void Start()
        {
            this.cameraBottomLeft = Camera.main.ViewportToWorldPoint(Camera.main.rect.min);
            this.cameraUpperRight = Camera.main.ViewportToWorldPoint(Camera.main.rect.max);
        }

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("umbrella");
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            this.StopTrackingDestroyedUmbrellas();
            Vector3 spawnPosition = this.GetRandomSpawnPosition();

            GameObject newUmbrella = Instantiate(this.UmbrellaPrefab, spawnPosition, Quaternion.identity);
            newUmbrella.GetComponent<UmbrellaController>().SetName(chatCommand.ChatMessage.Username);

            this.umbrellas.Add(newUmbrella);
        }

        public void OnDisable()
        {
            this.StopTrackingDestroyedUmbrellas();
            foreach (GameObject umbrella in this.umbrellas)
            {
                Destroy(umbrella);
            }
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = Random.Range(this.cameraBottomLeft.x + 0.5f, this.cameraUpperRight.x - 0.5f);
            Vector3 spawnPosition = new Vector3(randomX, this.cameraUpperRight.y);
            return spawnPosition;
        }

        private void StopTrackingDestroyedUmbrellas()
        {
            this.umbrellas.RemoveAll(u => u == null);
        }
    }
}