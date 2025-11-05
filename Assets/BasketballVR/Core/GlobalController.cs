using BasketballVR.Game;
using BasketballVR.UI;
using Fidgetland.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BasketballVR.Core
{
    public class GlobalController : MonoBehaviour
    {
        [SerializeField] private int _ballsCount;
        [SerializeField] private BallData[] _ballDataArray;
        [SerializeField] private ParticleSystem _goalVfx;

        private IUiService _uiService;
        private IUiService UiService => _uiService ??= Service.Instance.Get<IUiService>();

        private IGameService _gameService;
        private IGameService GameService => _gameService ??= Service.Instance.Get<IGameService>();

        private void OnEnable()
        {
            UiService.StartGamePressedEvent += HandleUiStartGamePressedEvent;
            UiService.RestartGamePressedEvent += HandleUiRestartGamePressedEvent;
            GameService.GoalEvent += HandleGameServiceGoalEvent;
        }

        private void OnDisable()
        {
            UiService.StartGamePressedEvent -= HandleUiStartGamePressedEvent;
            UiService.RestartGamePressedEvent -= HandleUiRestartGamePressedEvent;
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
            UiService.IncreaseScore(goalScore);
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