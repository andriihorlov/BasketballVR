using BasketballVR.Basket;
using BasketballVR.Game;
using BasketballVR.UI;
using UnityEngine;

namespace Fidgetland.ServiceLocator
{
    public static class ServiceLocator
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Init()
        {
            Service.Initialize();
            Service.Instance.Register(new UiService() as IUiService);
            Service.Instance.Register(new GameService() as IGameService);
            Service.Instance.Register(new BasketService() as IBasketNet);
        }
    }
}