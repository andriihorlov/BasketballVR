using System;
using System.Linq;
using BasketballVR.Game;
using UnityEngine;
using VContainer.Unity;

namespace BasketballVR.Basket
{
    public class BasketPresenter : IStartable, IDisposable
    {
        private readonly BasketView _basketView;
        private readonly IBasketModel _basketModel;

        public BasketPresenter(BasketView basketView, IBasketModel basketModel)
        {
            _basketView = basketView;
            _basketModel = basketModel;
        }

        public void Start()
        {
            _basketModel.InitCollidersEvent += HandleModelInitCollidersEvent;
            _basketView.BallInTheNetEvent += HandleBasketViewBallInTheNetEvent;
        }

        public void Dispose()
        {
            _basketModel.InitCollidersEvent -= HandleModelInitCollidersEvent;
            _basketView.BallInTheNetEvent -= HandleBasketViewBallInTheNetEvent;
        }

        private void HandleModelInitCollidersEvent(BallCollider[] colliders)
        {
            SphereCollider[] sphereColliders = colliders.Select(t => t.GetSphereCollider()).ToArray();
            ClothSphereColliderPair[] pairs = new ClothSphereColliderPair[colliders.Length];

            for (int i = 0; i < colliders.Length; i++)
            {
                ClothSphereColliderPair pair = new ClothSphereColliderPair
                {
                    first = sphereColliders[i],
                    second = null
                };
                
                pairs[i] = pair;
            }
            
            _basketView.InitColliders(pairs);
        }
        
        private void HandleBasketViewBallInTheNetEvent(Ball ball)
        {
            _basketModel.BallInTheGoal(ball);
        }
    }
}