using System;

namespace BasketballVR.Game
{
    public interface IGameModel
    {
        event Action<string> GoalEvent;
        event Action<BallCollider[]> UpdateBallColliderEvent;
        event Action<BallData[], int> InitBallVisualsEvent;

        void GameStart(BallData[] ballDataArray, int ballsCount);
        void GoalScored(string score);
        void UpdateBalls(BallCollider[] ballsColliders);
    }
}
