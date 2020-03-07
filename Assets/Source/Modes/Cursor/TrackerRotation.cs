namespace Assets.Source.Modes.Cursor
{
    using System.Linq;

    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public class TrackerRotation : CommandListenerMonoBehavior
    {
        public float RotationSpeed;

        public void Update()
        {
            this.transform.Rotate(Vector3.forward * this.RotationSpeed * Time.deltaTime);
        }

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("rotation") && chatCommand.HasParameters();
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            float newRotationSpeed;
            if (float.TryParse(chatCommand.ArgumentsAsList[0], out newRotationSpeed))
            {
                this.UpdateRotationSpeed(newRotationSpeed);
            }
        }

        private void UpdateRotationSpeed(float newRotationSpeed)
        {
            if (newRotationSpeed < 0f)
            {
                this.RotationSpeed = 0f;
            }
            else if (newRotationSpeed > 100f)
            {
                this.RotationSpeed = 100f;
            }
            else
            {
                this.RotationSpeed = newRotationSpeed;
            }
        }
    }
}