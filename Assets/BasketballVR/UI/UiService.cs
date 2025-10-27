using System;

namespace BasketballVR.UI
{
    public class UiService : IUiService
    {
        public event Action StartGamePressedEvent;
        public event Action RestartGamePressedEvent;

        private UiView _uiView;
        private int _score;

        public void Init(UiView uiView)
        {
            _uiView = uiView;
        }

        public void InvokeGameStart()
        {
            StartGamePressedEvent?.Invoke();
        }

        public void InvokeRestartGame()
        {
            _score = 0;
            RestartGamePressedEvent?.Invoke();
        }

        public void IncreaseScore(int score)
        {
            _score += score;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _uiView.UpdateTextScore(_score.ToString());
        }
    }
}