using System;
using BasketballVR.Game;

namespace BasketballVR.Basket
{
    public interface IBasketModel
    {
        event Action<BallCollider[]> InitCollidersEvent;
        event Action<string> BallScoredEvent;
        event Action ResetScoreEvent;
        
        void InitColliders(BallCollider[] colliders);
        void BallScored(string score);
        void ResetScore();
    }
}