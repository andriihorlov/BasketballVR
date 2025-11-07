using System;
using BasketballVR.Game;

namespace BasketballVR.Basket
{
    public interface IBasketModel
    {
        event Action<BallCollider[]> InitCollidersEvent;
        event Action<Ball> BallScoredEvent;
        
        void InitColliders(BallCollider[] colliders);
        void BallScored(Ball ball);
    }
}