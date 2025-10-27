using System;
using Fidgetland.ServiceLocator;

namespace BasketballVR.UI
{
    public interface IUiService : IService
    {
        event Action StartGamePressedEvent; 
        event Action RestartGamePressedEvent; 
        
        void Init(UiView uiView);
        void InvokeGameStart();
        void InvokeRestartGame();
        void IncreaseScore(int score);
    }
}
