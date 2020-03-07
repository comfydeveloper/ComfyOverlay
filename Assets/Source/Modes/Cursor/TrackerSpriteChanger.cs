namespace Assets.Source.Modes.Cursor
{
    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public class TrackerSpriteChanger : CommandListenerMonoBehavior
    {
        public Sprite[] Sprites;
        private SpriteRenderer spriteRenderer;

        public void Start()
        {
            this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("sprite") && chatCommand.HasParameters();
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            int spriteIndex;
            if (int.TryParse(chatCommand.ArgumentsAsList[0], out spriteIndex))
            {
                this.UpdateSprite(spriteIndex);
            }
        }

        private void UpdateSprite(int spriteIndex)
        {
            if (spriteIndex < 1 || spriteIndex > this.Sprites.Length)
            {
                System.Random random = new System.Random();
                int randomNextIndex = random.Next(0, this.Sprites.Length - 1);

                this.spriteRenderer.sprite = this.Sprites[randomNextIndex];
            }
            else
            {
                this.spriteRenderer.sprite = this.Sprites[spriteIndex - 1];
            }
        }
    }
}