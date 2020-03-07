namespace Assets.Source.Modes.Hat
{
    using UnityEngine;

    public class UmbrellaController : MonoBehaviour
    {
        public TextMesh Text;

        public void SetName(string userName)
        {
            this.Text.text = userName;
        }
    }
}