using System;

namespace BasketballVR.UI
{
    public interface IUiModel 
    {
        event Action StartGamePressedEvent; 
        event Action RestartGamePressedEvent;
        event Action<int> ScoreUpdatedEvent; 

        void InvokeGameStart();
        void InvokeRestartGame();
        void IncreaseScore(int score);
    }
}
