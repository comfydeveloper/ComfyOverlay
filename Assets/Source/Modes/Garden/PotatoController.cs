namespace Assets.Source.Modes.Garden
{
    using System;

    using UnityEngine;

    using Random = UnityEngine.Random;

    public class PotatoController : MonoBehaviour
    {
        [SerializeField] private float maxIdleTime;
        [SerializeField] private float movementSpeed;
        [SerializeField] private TextMesh text;

        private Animator animator;
        private Rigidbody2D body;
        private Vector2 targetPosition;
        private bool isMoving;
        private float nextMoveTime = 5f;
        private float idleTime;

        public void Start()
        {
            this.animator = this.GetComponent<Animator>();
            this.body = this.GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            if (!this.isMoving)
            {
                this.HandleIdle();
            }
            else
            {
                this.HandleMovement();
            }
        }

        private void HandleMovement()
        {
            Vector2 target = Vector2.MoveTowards(this.transform.position,
                                                 this.targetPosition,
                                                 this.movementSpeed * Time.deltaTime);
            this.body.MovePosition(target);

            if (HasReachedTargetLocation())
            {
                this.isMoving = false;
                this.animator.SetTrigger("Stop");
            }
        }

        private bool HasReachedTargetLocation()
        {
            return Math.Abs(this.targetPosition.x - this.transform.position.x) < 0.1f;
        }

        private void HandleIdle()
        {
            if (this.idleTime > this.nextMoveTime)
            {
                this.SetRandomTargetLocation();

                this.animator.SetTrigger(this.targetPosition.x < this.transform.position.x ? "GoLeft" : "GoRight");
                this.isMoving = true;
                this.idleTime = 0f;
                this.nextMoveTime = Random.Range(4f, this.maxIdleTime);
            }
            else
            {
                this.idleTime += Time.deltaTime;
            }
        }

        private void SetRandomTargetLocation()
        {
            Vector3 viewportBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 viewportTopRight = Camera.main.ViewportToWorldPoint(Vector3.one);
            float randomX = Random.Range(viewportBottomLeft.x + 2f, viewportTopRight.x - 2f);

            this.targetPosition = new Vector2(randomX, this.transform.position.y);
        }

        internal void SetName(string username)
        {
            this.text.text = username;
        }
    }
}