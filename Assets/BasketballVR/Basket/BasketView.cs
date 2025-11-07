using System;
using BasketballVR.Game;
using UnityEngine;

namespace BasketballVR.Basket
{
    public class BasketView : MonoBehaviour
    {
        [SerializeField] private BallTriggerEventReceiver _basketBallTriggerEventReceiver;
        [SerializeField] private Cloth _netCloth;

        public event Action<Ball> BallEnteredGoalEvent;
        
        private void OnEnable()
        {
            _basketBallTriggerEventReceiver.TriggerEntered += HandleEnteredGoalEvent;
        }

        private void OnDisable()
        {
            _basketBallTriggerEventReceiver.TriggerEntered -= HandleEnteredGoalEvent;
        }

        public void InitColliders(ClothSphereColliderPair[] clothSphereColliders)
        {
            _netCloth.sphereColliders = clothSphereColliders;
        }

        private void HandleEnteredGoalEvent(Ball scored)
        {
            BallEnteredGoalEvent?.Invoke(scored);
        }
    }
}
