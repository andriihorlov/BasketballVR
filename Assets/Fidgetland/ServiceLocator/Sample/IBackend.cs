using System;

namespace Fidgetland.ServiceLocator.Sample
{
    public interface IBackend : IService
    {
		event Action LoggedInEvent;
		event Action<string, string> TryLoginEvent;
		
		void Login(string login, string password);
		void LoginCompleted(bool isSucceed);
    }
}