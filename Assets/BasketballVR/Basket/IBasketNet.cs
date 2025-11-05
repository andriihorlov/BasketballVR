using System;
using Fidgetland.ServiceLocator;
using UnityEngine;

namespace BasketballVR.Basket
{
    public interface IBasketNet : IService
    {
        event Action<SphereCollider[]> InitCollidersEvent;
        void InitColliders(SphereCollider[] colliders);
    }
}