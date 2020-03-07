namespace Assets.Source.Modes.Hat
{
    using Assets.Source.Modes.Shared;

    using UnityEngine;

    public class HatOverlayMode : MonoBehaviour, IOverlayMode
    {
        public GameObject[] ElementsInMode;

        public bool Is(string modeName)
        {
            return modeName.ToLower() == "hat";
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