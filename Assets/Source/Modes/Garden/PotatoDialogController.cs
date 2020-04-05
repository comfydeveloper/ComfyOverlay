using Assets.Source.Twitch.Listeners;
using Assets.Source.Twitch.Wrappers;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Modes.Garden
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Assets.Source.Twitch;
    using Assets.Source.Twitch.Extensions;

    using Camera = UnityEngine.Camera;

    public class PotatoDialogController : MonoBehaviour, ITwitchCommandListener
    {
        [SerializeField]
        private GameObject dialogBoxPrefab;

        [SerializeField]
        private float dialogBoxOffset;

        private Text dialogBoxText;

        private GameObject dialogBox;

        private bool isDialogBoxOpen;

        public void Start()
        {
            this.RegisterListener();

            this.dialogBox = Instantiate(this.dialogBoxPrefab, this.transform.position, Quaternion.identity);
            GameObject parent = GameObject.FindWithTag("GardenUi");
            this.dialogBox.transform.SetParent(parent.transform);

            this.dialogBoxText = this.dialogBox.GetComponentInChildren<Text>();
        }

        private void RegisterListener()
        {
            IEnumerable<ITwitchHandler> listeners = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ITwitchHandler>();
            listeners.First().RegisterCommandListener(this);
        }

        public void Update()
        {
            Vector3 targetPos = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y + this.dialogBoxOffset, this.transform.position.z));
            this.dialogBox.transform.position = targetPos;
        }

        public void OnCommandReceived(IChatCommand chatCommand)
        {
            if (chatCommand.Is("say") && !this.isDialogBoxOpen)
            {
                this.isDialogBoxOpen = true;
                this.dialogBox.SetActive(true);
                this.dialogBoxText.text = chatCommand.ArgumentsAsString;

                StartCoroutine(this.CloseDialogBox());
            }
        }

        public IEnumerator CloseDialogBox()
        {
            yield return new WaitForSeconds(7);

            this.dialogBox.SetActive(false);
            this.isDialogBoxOpen = false;
        }
    }
}