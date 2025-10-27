using UnityEngine;

namespace BasketballVR.Game
{
    public class BallCollider : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        public Ball Ball { get; private set; }
        
        public void InjectBall(Ball ball)
        {
            Ball = ball;
        }

        public void InitPhysicsMaterial(PhysicsMaterial physicsMaterial)
        {
            _collider.material = physicsMaterial;
        }
    }
}