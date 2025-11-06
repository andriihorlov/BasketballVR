using System;
using BasketballVR.Game;

namespace BasketballVR.Basket
{
    public class BasketModel : IBasketModel
    {
        public event Action<BallCollider[]> InitCollidersEvent;
        public void InitColliders(BallCollider[] colliders)
        {
            InitCollidersEvent?.Invoke(colliders);
        }
    }
}