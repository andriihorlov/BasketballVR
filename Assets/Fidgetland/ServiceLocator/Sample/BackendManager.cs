using System;
using UnityEngine;

namespace Fidgetland.ServiceLocator.Sample
{
    public class BackendManager : IBackend
    {
        public event Action LoggedInEvent;
        public event Action<string, string> TryLoginEvent;
		
		public void Login(string login, string password)
		{
			TryLoginEvent?.Invoke(login, password);
		}
		
		public void LoginCompleted(bool isSucceed)
		{
			if (isSucceed)
			{
				LoggedInEvent?.Invoke();
				return;
			}
			
			Debug.LogError("Wrong login or password!");
		}
    }
}