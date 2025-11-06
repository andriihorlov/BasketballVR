using System;
using BasketballVR.Game;

namespace BasketballVR.Basket
{
    public interface IBasketModel
    {
        event Action<BallCollider[]> InitCollidersEvent;
        event Action<Ball> BallInTheNetEvent;
        
        void InitColliders(BallCollider[] colliders);
        void BallInTheGoal(Ball ball);
    }
}