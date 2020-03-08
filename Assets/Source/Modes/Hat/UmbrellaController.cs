namespace Assets.Source.Modes.Hat
{
    using UnityEngine;

    public class UmbrellaController : MonoBehaviour
    {
        public TextMesh Text;

        private Rigidbody2D body;

        public void Start()
        {
            this.body = this.GetComponent<Rigidbody2D>();
            this.SetInitialFallVelocity();
        }

        private void SetInitialFallVelocity()
        {
            float randomX = Random.Range(-3f, 3f);
            float randomY = Random.Range(-0.5f, -1f);
            this.body.velocity = new Vector2(randomX, randomY);
        }

        public void SetName(string userName)
        {
            this.Text.text = userName;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DestructionPlane"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}