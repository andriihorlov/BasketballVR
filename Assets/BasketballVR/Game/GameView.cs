using System.Collections.Generic;
using BasketballVR.Basket;
using Fidgetland.ServiceLocator;
using UnityEngine;

namespace BasketballVR.Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private BallTriggerEventReceiver _basketBallTriggerEventReceiver;
        [SerializeField] private BallTriggerEventReceiver _dangerBallAreaTriggerEventReceiver;
        [SerializeField] private Ball[] _balls;

        [Space] [SerializeField] private Ball _ballPrefab;
        [SerializeField] private SpawnArea _spawnArea;

        private IGameService _gameService;
        private IGameService GameService => _gameService ??= Service.Instance.Get<IGameService>();

        private IBasketNet _basketNet;
        private IBasketNet BasketNet => _basketNet??= Service.Instance.Get<IBasketNet>();
        
        private void Start()
        {
            GameService.Init(this);
            CheckReferences();
        }

        private void OnEnable()
        {
            _basketBallTriggerEventReceiver.TriggerEntered += HandleBasketEnteredEvent;
            _dangerBallAreaTriggerEventReceiver.TriggerEntered += HandleDangerAreaEnteredEvent;
        }

        private void OnDisable()
        {
            _basketBallTriggerEventReceiver.TriggerEntered -= HandleBasketEnteredEvent;
            _dangerBallAreaTriggerEventReceiver.TriggerEntered -= HandleDangerAreaEnteredEvent;
        }

        public void SetBalls(BallData[] ballDataArray)
        {
            List<SphereCollider> sphereColliders = new List<SphereCollider>(); 
            
            for (int ballIndex = 0; ballIndex < ballDataArray.Length; ballIndex++)
            {
                Vector3 position = _spawnArea == null ? Vector3.zero : _spawnArea.GetRandomPoint();
                Ball ball = ballIndex < _balls.Length ? _balls[ballIndex] : Instantiate(_ballPrefab);
                ball.Init(ballDataArray[ballIndex], position);
                ball.gameObject.SetActive(true);
                sphereColliders.Add(ball.Collider);
            }

            for (int index = ballDataArray.Length; index < _balls.Length; index++)
            {
                _balls[index].gameObject.SetActive(false);
            }
            
            BasketNet.InitColliders(sphereColliders.ToArray());
        }

        private void HandleBasketEnteredEvent(Ball ball)
        {
            GameService.GoalScored(ball.BallScore);
        }

        private void HandleDangerAreaEnteredEvent(Ball ball)
        {
            ball.ResetBall();
        }

        private void CheckReferences()
        {
            if (_balls == null ||  _balls.Length < 1)
            {
                Debug.LogWarning($"[{name}] To use Object Pool, better to fill the array {nameof(_balls)}.");
            }

            if (_spawnArea == null)
            {
                Debug.LogError($"[{name}] Please add {nameof(SpawnArea)} to the scene and reference here.");
            }

            if (_basketBallTriggerEventReceiver == null)
            {
                Debug.LogWarning($"[{name}] To make the game works, add the {nameof(_basketBallTriggerEventReceiver)}.");
            }
        }
    }
}