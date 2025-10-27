using Fidgetland.ServiceLocator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BasketballVR.UI
{
    public class UiView : MonoBehaviour
    {
        [Header("Start Canvas")]
        [SerializeField] private GameObject _startCanvas;
        [SerializeField] private Button _startGameButton;

        [Header("Score Canvas")]
        [SerializeField] private GameObject _scoreCanvas;
        [SerializeField] private TextMeshProUGUI _scoreTextMeshPro; 
        
        [Header("Restart Canvas")]
        [SerializeField] private GameObject _restartCanvas;
        [SerializeField] private Button _restartButton;

        [Header("Message Canvas")]
        [SerializeField] private GameObject _scoredMessageCanvas;

        private IUiService _uiService;
        private IUiService UiService => _uiService ??= Service.Instance.Get<IUiService>();

        private void Awake()
        {
            HideMessageScoredCanvas();
        }

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(HandleStartButtonPressed);
            _restartButton.onClick.AddListener(HandleRestartButtonPressed);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(HandleStartButtonPressed);
            _restartButton.onClick.RemoveListener(HandleRestartButtonPressed);
        }
        
        public void UpdateTextScore(string score)
        {
            _scoredMessageCanvas.SetActive(true);
            _scoreTextMeshPro.text = score;
            Invoke(nameof(HideMessageScoredCanvas), 2f);
        }

        private void Start()
        {
            UiService.Init(this);
            ToggleGameCanvas(false);
        }

        private void HandleStartButtonPressed()
        {
            UiService.InvokeGameStart();
            ToggleGameCanvas(true);
        }

        private void HandleRestartButtonPressed()
        {
            UiService.InvokeRestartGame();
        }

        private void ToggleGameCanvas(bool isActive)
        {
            _scoreCanvas.gameObject.SetActive(isActive);
            _restartCanvas.gameObject.SetActive(isActive);
            _startCanvas.gameObject.SetActive(!isActive);
        }

        private void HideMessageScoredCanvas()
        {
            _scoredMessageCanvas.SetActive(false);
        }
    }
}