using System;
using VContainer.Unity;

namespace BasketballVR.UI
{
    public class UiPresenter : IStartable, IDisposable
    {
        private readonly UiView _uiView;
        private readonly IUiModel _uiModel;
        
        private int _score;

        public UiPresenter(UiView uiView, IUiModel uiModel)
        {
            _uiView = uiView;
            _uiModel = uiModel;
        }

        public void Start()
        {
            _uiView.GameStartClickedEvent += HandleViewGameStartClickedEvent;
            _uiView.GameRestartClickedEvent += HandleViewGameRestartClickedEvent;
            _uiModel.ScoreUpdatedEvent += HandleModelScoreUpdatedEvent;
        }

        public void Dispose()
        {
            _uiView.GameStartClickedEvent -= HandleViewGameStartClickedEvent;
            _uiView.GameRestartClickedEvent -= HandleViewGameRestartClickedEvent;
            _uiModel.ScoreUpdatedEvent -= HandleModelScoreUpdatedEvent;
        }

        private void HandleViewGameStartClickedEvent()
        {
            _uiModel.InvokeGameStart();
        }

        private void HandleViewGameRestartClickedEvent()
        {
            _score = 0;
            _uiModel.InvokeRestartGame();
        }

        private void HandleModelScoreUpdatedEvent(int score)
        {
            _score += score;
            _uiView.UpdateTextScore(score.ToString());
        }
    }
}