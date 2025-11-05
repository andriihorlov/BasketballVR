using BasketballVR.Game;
using BasketballVR.UI;
using Fidgetland.ServiceLocator;
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

        private IGameService _gameService;
        private IGameService GameService => _gameService ??= Service.Instance.Get<IGameService>();

        private void Start()
        {
            _uiModel.StartGamePressedEvent += HandleUiStartGamePressedEvent;
            _uiModel.RestartGamePressedEvent += HandleUiRestartGamePressedEvent;
            GameService.GoalEvent += HandleGameServiceGoalEvent;
        }

        private void OnDestroy()
        {
            _uiModel.StartGamePressedEvent -= HandleUiStartGamePressedEvent;
            _uiModel.RestartGamePressedEvent -= HandleUiRestartGamePressedEvent;
            GameService.GoalEvent -= HandleGameServiceGoalEvent;
        }

        private void HandleUiStartGamePressedEvent()
        {
            GameService.GameStart(_ballDataArray, _ballsCount);
        }

        private void HandleUiRestartGamePressedEvent()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void HandleGameServiceGoalEvent(int goalScore)
        {
            _uiModel.IncreaseScore(goalScore);
            _goalVfx.Play();
        }

#if UNITY_EDITOR
        [ContextMenu("Simulate Goal")]
        private void GoalEditor()
        {
            HandleGameServiceGoalEvent(1);
        }

        [ContextMenu("Simulate Restart")]
        private void RestartEditor()
        {
            HandleUiRestartGamePressedEvent();
        }
#endif
    }
}