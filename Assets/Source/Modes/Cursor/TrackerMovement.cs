

namespace Assets.Source.Modes.Cursor
{
    using Assets.Source.Modes.Shared;
    using Assets.Source.Twitch.Extensions;
    using Assets.Source.Twitch.Wrappers;

    using UnityEngine;

    public class TrackerMovement : CommandListenerMonoBehavior
    {
        public float MovementSpeed = 10f;

        public void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 targetPosition = new Vector3(worldPosition.x, worldPosition.y);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, this.MovementSpeed * Time.deltaTime);
        }

        protected override bool CanHandle(IChatCommand chatCommand)
        {
            return chatCommand.Is("speed") && chatCommand.HasParameters();
        }

        protected override void Handle(IChatCommand chatCommand)
        {
            float newMovementSpeed;
            if (float.TryParse(chatCommand.ArgumentsAsList[0], out newMovementSpeed))
            {
                this.UpdateMovementSpeed(newMovementSpeed);
            }
        }

        private void UpdateMovementSpeed(float newMovementSpeed)
        {
            if (newMovementSpeed < 0f)
            {
                this.MovementSpeed = 0f;
            }
            else if (newMovementSpeed > 100f)
            {
                this.MovementSpeed = 10f;
            }
            else
            {
                this.MovementSpeed = newMovementSpeed / 10f;
            }
        }
    }
}
