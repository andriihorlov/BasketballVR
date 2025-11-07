using System;
using System.Collections.Generic;
using UnityEngine;

namespace BasketballVR.Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private BallTriggerEventReceiver _dangerBallAreaTriggerEventReceiver;
        [SerializeField] private Ball[] _balls;

        [Space] 
        [SerializeField] private Ball _ballPrefab;
        [SerializeField] private SpawnArea _spawnArea;

        public event Action<BallCollider[]> UpdateBallsEvent;
        
        private void Start()
        {
            CheckReferences();
        }

        private void OnEnable()
        {
            _dangerBallAreaTriggerEventReceiver.TriggerEntered += HandleDangerAreaEnteredEvent;
        }

        private void OnDisable()
        {
            _dangerBallAreaTriggerEventReceiver.TriggerEntered -= HandleDangerAreaEnteredEvent;
        }

        public void InitBalls(BallData[] ballDataArray)
        {
            List<BallCollider> ballColliders = new List<BallCollider>(); 
            
            for (int ballIndex = 0; ballIndex < ballDataArray.Length; ballIndex++)
            {
                Vector3 position = _spawnArea == null ? Vector3.zero : _spawnArea.GetRandomPoint();
                Ball ball = ballIndex < _balls?.Length ? _balls[ballIndex] : Instantiate(_ballPrefab);
                ball.Init(ballDataArray[ballIndex], position);
                ball.gameObject.SetActive(true);
                ballColliders.Add(ball.BallCollider);
            }

            for (int index = ballDataArray.Length; index < _balls?.Length; index++)
            {
                _balls[index].gameObject.SetActive(false);
            }
            
            UpdateBallsEvent?.Invoke(ballColliders.ToArray());
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

            if (_dangerBallAreaTriggerEventReceiver == null)
            {
                Debug.LogWarning($"[{name}] Missing reference: {nameof(_dangerBallAreaTriggerEventReceiver)}.");
            }
        }
    }
}