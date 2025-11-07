using System;
using BasketballVR.Game;

namespace BasketballVR.Basket
{
    public class BasketModel : IBasketModel
    {
        public event Action<BallCollider[]> InitCollidersEvent;
        public event Action<string> BallScoredEvent;
        public event Action ResetScoreEvent;

        public void InitColliders(BallCollider[] colliders)
        {
            InitCollidersEvent?.Invoke(colliders);
        }

        public void BallScored(string score)
        {
            BallScoredEvent?.Invoke(score);
        }

        public void ResetScore()
        {
            ResetScoreEvent?.Invoke();
        }
    }
}