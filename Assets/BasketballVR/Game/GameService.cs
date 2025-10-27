using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace BasketballVR.Game
{
    public class GameService : IGameService
    {
        public event Action<int> GoalEvent;
        
        private GameView _gameView;

        public void Init(GameView gameView)
        {
            _gameView = gameView;
        }

        public void GameStart(BallData[] ballDataArray, int ballsCount)
        {
            _gameView.SetBalls(GetBallData(ballDataArray, ballsCount));
        }

        public void GoalScored(int score)
        {
            GoalEvent?.Invoke(score);
        }

        private BallData[] GetBallData(BallData[] defaultDataArray, int ballsCount)
        {
            List<BallData> ballList = new List<BallData>();
            
            for (int ballIndex = 0; ballIndex < ballsCount; ballIndex++)
            {
                int index = Random.Range(0, defaultDataArray.Length);
                ballList.Add(defaultDataArray[index]);
            }

            return ballList.ToArray();
        }
    }
}