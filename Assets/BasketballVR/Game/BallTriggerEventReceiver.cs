using System;
using UnityEngine;

namespace BasketballVR.Game
{
    [RequireComponent(typeof(Collider))]
    public class BallTriggerEventReceiver : MonoBehaviour
    {
        [SerializeField] private bool _isCheckFromTop;
        
        private Transform _currentTransform;
        
        public event Action<Ball> TriggerEntered;

        private void Awake()
        {
            _currentTransform = transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            Ball ball = GetBall(other);
            if (ball == null)
            {
                return;
            }

            if (ball.IsGrabbed)
            {
                return;
            }
            
            if (!_isCheckFromTop || IsCameFromTop(ball))
            {
                TriggerEntered?.Invoke(ball);
            }
        }

        private Ball GetBall(Collider otherCollider)
        {
            BallCollider ballCollider = otherCollider.GetComponent<BallCollider>();
            return ballCollider != null ? ballCollider.Ball : otherCollider.GetComponent<Ball>();
        }

        private bool IsCameFromTop(Ball ball)
        {
            Vector3 ballToTrigger = (_currentTransform.position - ball.transform.position).normalized;
            Vector3 ballVelocity = ball.GetVelocity();
            if (ballVelocity.sqrMagnitude < 0.01f)
            {
                return false;
            }
            
            Vector3 up = _currentTransform.up;
            return Vector3.Dot(ballVelocity, up) < 0f && Vector3.Dot(ballToTrigger, up) < 0f;
        }
    }
}