using System;
using UnityEngine;

namespace BasketballVR.Basket
{
    public class BasketService : IBasketNet
    {
        public event Action<SphereCollider[]> InitCollidersEvent;

        public void InitColliders(SphereCollider[] colliders)
        {
            InitCollidersEvent?.Invoke(colliders);
        }
    }
}