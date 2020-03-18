namespace Assets.Source.Modes.Garden
{
    using UnityEngine;

    public class GardenPlacer : MonoBehaviour
    {
        public void Update()
        {
            Vector3 viewportBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            this.transform.position = new Vector3(this.transform.position.x, viewportBottomLeft.y);
        }
    }
}