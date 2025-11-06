using System;

namespace BasketballVR.UI
{
    public class UiModel : IUiModel
    {
        public event Action StartGamePressedEvent;
        public event Action RestartGamePressedEvent;
        public event Action<int> ScoreUpdatedEvent;


        public void InvokeGameStart()
        {
            StartGamePressedEvent?.Invoke();
        }

        public void InvokeRestartGame()
        {
            RestartGamePressedEvent?.Invoke();
        }

        public void IncreaseScore(int score)
        {
            ScoreUpdatedEvent?.Invoke(score);
        }
    }
}