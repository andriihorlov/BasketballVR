using System;
using BasketballVR.Game;
using Fidgetland.ServiceLocator;
using UnityEngine;

namespace BasketballVR.Basket
{
    public interface IBasketModel
    {
        event Action<BallCollider[]> InitCollidersEvent;
        void InitColliders(BallCollider[] colliders);
    }
}