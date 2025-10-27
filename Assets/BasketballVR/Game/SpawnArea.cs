using UnityEngine;
using Random = UnityEngine.Random;

namespace BasketballVR.Game
{
    public class SpawnArea : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public Vector3 GetRandomPoint()
        {
            Vector3 colliderSize = _collider.size;
            Vector3 localPoint = new Vector3(
                Random.Range(-colliderSize.x / 2f, colliderSize.x / 2f),
                Random.Range(-_collider.size.y / 2f, colliderSize.y / 2f),
                Random.Range(-_collider.size.z / 2f, colliderSize.z / 2f)
            );
            
            return _transform.TransformPoint(localPoint + _collider.center);
        }
    }
}