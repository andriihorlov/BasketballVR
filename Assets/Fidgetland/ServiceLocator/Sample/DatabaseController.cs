using UnityEngine;

namespace Fidgetland.ServiceLocator.Sample
{
    public class DatabaseController : MonoBehaviour
    {
        private IBackend _backend;
        private IBackend Backend => _backend ??= Service.Instance.Get<IBackend>();

        private void OnEnable()
        {
            Backend.TryLoginEvent += BackendOnTryLoginEvent;
        }

        private void OnDisable()
        {
            Backend.TryLoginEvent -= BackendOnTryLoginEvent;
        }

        private void BackendOnTryLoginEvent(string login, string password)
        {
            Backend.LoginCompleted(IsLoginDataOk(login, password));
        }
        
        private bool IsLoginDataOk(string login, string password)
        {
            // check from data base if it's okay
            // return DataBase.CheckLoginData(login, password);
            return true;
        }
    }
}