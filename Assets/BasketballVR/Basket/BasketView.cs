using Fidgetland.ServiceLocator;
using UnityEngine;

namespace BasketballVR.Basket
{
    public class BasketView : MonoBehaviour
    {
        [SerializeField] private Cloth _netCloth;

        private IBasketNet _basketNet;
        private IBasketNet BasketNet => _basketNet??= Service.Instance.Get<IBasketNet>();

        private void OnEnable()
        {
            BasketNet.InitCollidersEvent += BasketNetOnInitCollidersEvent;
        }

        private void OnDisable()
        {
            BasketNet.InitCollidersEvent -= BasketNetOnInitCollidersEvent;
        }

        private void BasketNetOnInitCollidersEvent(SphereCollider[] colliders)
        {
            ClothSphereColliderPair[] pairs = new ClothSphereColliderPair[colliders.Length];

            for (int i = 0; i < colliders.Length; i++)
            {
                ClothSphereColliderPair pair = new ClothSphereColliderPair
                {
                    first = colliders[i],
                    second = null
                };
                
                pairs[i] = pair;
            }

            _netCloth.sphereColliders = pairs;
        }
    }
}
