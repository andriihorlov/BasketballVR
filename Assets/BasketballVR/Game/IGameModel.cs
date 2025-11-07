using System;

namespace BasketballVR.Game
{
    public interface IGameModel
    {
        event Action<BallCollider[]> UpdateBallColliderEvent;
        event Action<BallData[], int> InitBallVisualsEvent;

        void GameStart(BallData[] ballDataArray, int ballsCount);
        void UpdateBalls(BallCollider[] ballsColliders);
    }
}
