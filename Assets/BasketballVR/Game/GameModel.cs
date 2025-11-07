using System;

namespace BasketballVR.Game
{
    public class GameModel : IGameModel
    {
        public event Action<BallCollider[]> UpdateBallColliderEvent;
        public event Action<BallData[], int> InitBallVisualsEvent;

        public void GameStart(BallData[] ballDataArray, int ballsCount)
        {
            InitBallVisualsEvent?.Invoke(ballDataArray, ballsCount);
        }

        public void UpdateBalls(BallCollider[] ballsColliders)
        {
            UpdateBallColliderEvent?.Invoke(ballsColliders);
        }
    }
}