using System;
using System.Collections.Generic;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace BasketballVR.Game
{
    public class GamePresenter : IStartable, IDisposable
    {
        private readonly GameView _gameView;
        private readonly IGameModel _gameModel;
        private int _score;

        public GamePresenter(GameView gameView, IGameModel gameModel)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Start()
        {
            _gameView.ScoredBallEvent += HandleGameViewScoredBallEvent;
            _gameView.UpdateBallsEvent += HandleUpdateBallsEvent;
            _gameModel.InitBallVisualsEvent += HandleInitBallVisualsEvent;
        }

        public void Dispose()
        {
            _gameView.ScoredBallEvent -= HandleGameViewScoredBallEvent;
            _gameView.UpdateBallsEvent -= HandleUpdateBallsEvent;
            _gameModel.InitBallVisualsEvent -= HandleInitBallVisualsEvent;
        }

        private void HandleGameViewScoredBallEvent(int score)
        {
            _score += score;
            _gameModel.GoalScored(_score.ToString());
        }

        private void HandleUpdateBallsEvent(BallCollider[] ballsColliders)
        {
            _gameModel.UpdateBalls(ballsColliders);
        }

        private void HandleInitBallVisualsEvent(BallData[] ballsData, int ballsCount)
        {
            _gameView.InitBalls(GetBallData(ballsData, ballsCount));
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