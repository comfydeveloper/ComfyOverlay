namespace Assets.Source.Camera
{
    using UnityEngine;

    public class CameraBoundarySetter : MonoBehaviour
    {
        public CameraBoundaryDirection Direction;

        public void Update()
        {
            Vector3 viewportBottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 viewportTopRight = Camera.main.ViewportToWorldPoint(Vector3.one);

            switch (this.Direction)
            {
                case CameraBoundaryDirection.Left:
                    this.transform.position = new Vector3(viewportBottomLeft.x, this.transform.position.y);
                    break;
                case CameraBoundaryDirection.Right:
                    this.transform.position = new Vector3(viewportTopRight.x, this.transform.position.y);
                    break;
                case CameraBoundaryDirection.Top:
                    this.transform.position = new Vector3(this.transform.position.x, viewportTopRight.y);
                    break;
                case CameraBoundaryDirection.Bottom:
                    this.transform.position = new Vector3(this.transform.position.x, viewportBottomLeft.y);
                    break;
            }
        }
    }
}