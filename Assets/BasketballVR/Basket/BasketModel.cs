using System;
using BasketballVR.Game;

namespace BasketballVR.Basket
{
    public class BasketModel : IBasketModel
    {
        public event Action<BallCollider[]> InitCollidersEvent;
        public event Action<Ball> BallInTheNetEvent;

        public void InitColliders(BallCollider[] colliders)
        {
            InitCollidersEvent?.Invoke(colliders);
        }

        public void BallInTheGoal(Ball ball)
        {
            BallInTheNetEvent?.Invoke(ball);
        }
    }
}