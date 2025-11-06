using UnityEngine;

namespace BasketballVR.Basket
{
    public class BasketView : MonoBehaviour
    {
        [SerializeField] private Cloth _netCloth;

        public void InitColliders(SphereCollider[] colliders)
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
