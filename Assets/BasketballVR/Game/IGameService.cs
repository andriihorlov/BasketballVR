using System;
using Fidgetland.ServiceLocator;

namespace BasketballVR.Game
{
    public interface IGameService : IService
    {
        public event Action<int> GoalEvent;
        
        void Init(GameView gameView);
        void GameStart(BallData[] ballDataArray, int ballsCount);
        void GoalScored(int score);
    }
}
