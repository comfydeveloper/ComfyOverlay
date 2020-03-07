namespace Assets.Source.Modes.Cursor
{
    using System.Linq;

    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public class TrackerRotation : CommandListenerMonoBehavior
    {
        private float rotationSpeed;

        public void Update()
        {
            this.transform.Rotate(Vector3.forward * this.rotationSpeed * Time.deltaTime);
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
                this.rotationSpeed = 0f;
            }
            else if (newRotationSpeed > 50f)
            {
                this.rotationSpeed = 50f;
            }
            else
            {
                this.rotationSpeed = newRotationSpeed;
            }
        }
    }
}