using System;
using Fidgetland.ServiceLocator;

namespace BasketballVR.UI
{
    public interface IUiModel : IService
    {
        event Action StartGamePressedEvent; 
        event Action RestartGamePressedEvent;
        event Action<int> ScoreUpdatedEvent; 

        void InvokeGameStart();
        void InvokeRestartGame();
        void IncreaseScore(int score);
    }
}
