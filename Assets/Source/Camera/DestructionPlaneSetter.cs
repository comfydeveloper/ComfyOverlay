namespace Assets.Source.Camera
{
    using UnityEngine;

    public class DestructionPlaneSetter : MonoBehaviour
    {
        public void Update()
        {
            Vector3 viewportBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            this.transform.position = new Vector3(this.transform.position.x, viewportBottomLeft.y - 2.5f);
        }
    }
}