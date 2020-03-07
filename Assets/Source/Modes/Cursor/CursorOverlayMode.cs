namespace Assets.Source.Modes.Cursor
{
    using Assets.Source.Modes.Shared;

    using UnityEngine;

    public class CursorOverlayMode : MonoBehaviour, IOverlayMode
    {
        public GameObject[] ElementsInMode;

        public bool Is(string modeName)
        {
            return modeName.ToLower() == "cursor";
        }

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