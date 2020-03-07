namespace Assets.Source
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LoginHandler : MonoBehaviour
    {
        public InputField UserNameInput;
        public InputField OAuthInput;
        public InputField ChannelInput;

        public string SceneAfterLogin;

        public void Start()
        {
            this.UserNameInput.text = PlayerPrefs.GetString("user", string.Empty);
            this.OAuthInput.text = PlayerPrefs.GetString("oauth", string.Empty);
            this.ChannelInput.text = PlayerPrefs.GetString("channel", string.Empty);
        }

        public void OnLogin()
        {
            PlayerPrefs.SetString("user", this.UserNameInput.text);
            PlayerPrefs.SetString("oauth", this.OAuthInput.text);
            PlayerPrefs.SetString("channel", this.ChannelInput.text);

            SceneManager.LoadScene(this.SceneAfterLogin);
        }
    }
}