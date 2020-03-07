namespace Assets.Source.Modes.Cursor
{
    using Assets.Source.Modes.Shared;

    using UnityEngine;

    public class CursorOverlayMode : MonoBehaviour, IOverlayMode
    {
        public GameObject[] ElementsInMode;

        public void Enable()
        {
            foreach (GameObject element in this.ElementsInMode)
            {
                element.SetActive(true);
            }
        }

        public void Disable()
        {
            foreach (GameObject element in this.ElementsInMode)
            {
                element.SetActive(false);
            }
        }
    }
}