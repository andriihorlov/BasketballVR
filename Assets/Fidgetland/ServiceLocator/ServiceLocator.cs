using BasketballVR.Basket;
using BasketballVR.Game;
using UnityEngine;

namespace Fidgetland.ServiceLocator
{
    public static class ServiceLocator
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Init()
        {
            Service.Initialize();
            Service.Instance.Register(new BasketService() as IBasketModel);
        }
    }
}