using System;
using System.Linq;
using BasketballVR.Game;
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
        }

        public void Dispose()
        {
            _basketModel.InitCollidersEvent -= HandleModelInitCollidersEvent;
        }

        private void HandleModelInitCollidersEvent(BallCollider[] colliders)
        {
            _basketView.InitColliders(colliders.Select(t => t.GetSphereCollider()).ToArray());
        }
    }
}