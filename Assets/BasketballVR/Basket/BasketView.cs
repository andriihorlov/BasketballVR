using System;
using BasketballVR.Game;
using UnityEngine;

namespace BasketballVR.Basket
{
    public class BasketView : MonoBehaviour
    {
        [SerializeField] private BallTriggerEventReceiver _basketBallTriggerEventReceiver;
        [SerializeField] private Cloth _netCloth;

        public event Action<Ball> BallInTheNetEvent;
        
        private void OnEnable()
        {
            _basketBallTriggerEventReceiver.TriggerEntered += HandleBasketEnteredEvent;
        }

        private void OnDisable()
        {
            _basketBallTriggerEventReceiver.TriggerEntered -= HandleBasketEnteredEvent;
        }

        public void InitColliders(ClothSphereColliderPair[] clothSphereColliders)
        {
            _netCloth.sphereColliders = clothSphereColliders;
        }

        private void HandleBasketEnteredEvent(Ball scored)
        {
            BallInTheNetEvent?.Invoke(scored);
        }
    }
}
