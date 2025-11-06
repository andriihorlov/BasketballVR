using System;

namespace BasketballVR.Game
{
    public class GameModel : IGameModel
    {
        public event Action<string> GoalEvent;
        public event Action<BallCollider[]> UpdateBallColliderEvent;
        public event Action<BallData[], int> InitBallVisualsEvent;

        public void GameStart(BallData[] ballDataArray, int ballsCount)
        {
            InitBallVisualsEvent?.Invoke(ballDataArray, ballsCount);
        }

        public void GoalScored(string score)
        {
            GoalEvent?.Invoke(score);
        }

        public void UpdateBalls(BallCollider[] ballsColliders)
        {
            UpdateBallColliderEvent?.Invoke(ballsColliders);
        }
    }
}