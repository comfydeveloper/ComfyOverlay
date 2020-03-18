namespace Assets.Source.Modes.Garden
{
    using Assets.Source.Modes.Shared;

    using UnityEngine;

    public class GardenOverlayMode : MonoBehaviour, IOverlayMode
    {
        public GameObject[] ElementsInMode;

        public bool Is(string modeName)
        {
            return modeName.ToLower() == "garden";
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