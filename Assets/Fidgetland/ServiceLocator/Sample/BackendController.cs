using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fidgetland.ServiceLocator.Sample
{
    public class BackendController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _loginInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        [SerializeField] private Button _loginButton;

        private IBackend _backend;
        private IBackend Backend => _backend ??= Service.Instance.Get<IBackend>();

        private void OnEnable()
        {
            _loginButton.onClick.AddListener(LoginButtonClicked);
            Backend.LoggedInEvent += SuccessfulLogin;
        }

        private void OnDisable()
        {
            _loginButton.onClick.RemoveListener(LoginButtonClicked);
            Backend.LoggedInEvent -= SuccessfulLogin;
        }

        private void LoginButtonClicked()
        {
            Backend.Login(_loginInputField.text, _passwordInputField.text);
        }
        
        private void SuccessfulLogin()
        {
            // user Successfully logged in
        }
    }
}
