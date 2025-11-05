using UnityEngine;

namespace BasketballVR.Game
{
    public class BallCollider : MonoBehaviour
    {
        [SerializeField] private SphereCollider _collider;
        public Ball Ball { get; private set; }
        
        public void InjectBall(Ball ball)
        {
            Ball = ball;
        }

        public void InitPhysicsMaterial(PhysicsMaterial physicsMaterial)
        {
            _collider.material = physicsMaterial;
        }

        public SphereCollider GetSphereCollider() => _collider;
    }
}