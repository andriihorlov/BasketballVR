using System;

namespace BasketballVR.UI
{
    public class UiModel : IUiModel
    {
        public event Action StartGamePressedEvent;
        public event Action RestartGamePressedEvent;
        public event Action<int> ScoreUpdatedEvent;

        private int _score;

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
            ScoreUpdatedEvent?.Invoke(_score);
        }
    }
}