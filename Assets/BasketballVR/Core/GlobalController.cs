using BasketballVR.Basket;
using BasketballVR.Game;
using BasketballVR.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace BasketballVR.Core
{
    public class GlobalController : MonoBehaviour
    {
        [SerializeField] private int _ballsCount;
        [SerializeField] private BallData[] _ballDataArray;
        [SerializeField] private ParticleSystem _goalVfx;

        [Inject] private IUiModel _uiModel;       
        [Inject] private IGameModel _gameModel;
        [Inject] private IBasketModel _basketModel;

        private void Start()
        {
            _uiModel.StartGamePressedEvent += HandleUiStartGamePressedEvent;
            _uiModel.RestartGamePressedEvent += HandleUiRestartGamePressedEvent;

            _gameModel.UpdateBallColliderEvent += HandleGameUpdateBallColliderEvent;
            _basketModel.BallScoredEvent += HandleBasketBallEnteredGoalEvent;
        }

        private void OnDestroy()
        {
            _uiModel.StartGamePressedEvent -= HandleUiStartGamePressedEvent;
            _uiModel.RestartGamePressedEvent -= HandleUiRestartGamePressedEvent;

            _gameModel.UpdateBallColliderEvent -= HandleGameUpdateBallColliderEvent;
            _basketModel.BallScoredEvent -= HandleBasketBallEnteredGoalEvent;
        }

        private void HandleUiStartGamePressedEvent()
        {
            _gameModel.GameStart(_ballDataArray, _ballsCount);
        }

        private void HandleUiRestartGamePressedEvent()
        {
            _gameModel.Restart();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void HandleBasketBallEnteredGoalEvent(Ball ball)
        {
            _uiModel.UpdateScore(ball.BallScore.ToString());
            _goalVfx.Play();
        }
        
        private void HandleGameUpdateBallColliderEvent(BallCollider[] ballColliders)
        {
            _basketModel.InitColliders(ballColliders);
        }

#if UNITY_EDITOR
        [ContextMenu("Simulate Goal")]
        private void GoalEditor()
        {
            _uiModel.UpdateScore(1.ToString());
            _goalVfx.Play();
        }

        [ContextMenu("Simulate Restart")]
        private void RestartEditor()
        {
            HandleUiRestartGamePressedEvent();
        }
#endif
    }
}