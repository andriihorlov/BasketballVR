using System;

namespace BasketballVR.UI
{
    public interface IUiModel 
    {
        event Action StartGamePressedEvent; 
        event Action RestartGamePressedEvent;
        event Action<string> ScoreUpdatedEvent; 

        void InvokeGameStart();
        void InvokeRestartGame();
        void UpdateScore(string score);
    }
}
