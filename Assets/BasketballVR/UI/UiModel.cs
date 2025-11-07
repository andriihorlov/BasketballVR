using System;

namespace BasketballVR.UI
{
    public class UiModel : IUiModel
    {
        public event Action StartGamePressedEvent;
        public event Action RestartGamePressedEvent;
        public event Action<string> ScoreUpdatedEvent;

        public void InvokeGameStart()
        {
            StartGamePressedEvent?.Invoke();
        }

        public void InvokeRestartGame()
        {
            RestartGamePressedEvent?.Invoke();
        }

        public void UpdateScore(string score)
        {
            ScoreUpdatedEvent?.Invoke(score);
        }
    }
}