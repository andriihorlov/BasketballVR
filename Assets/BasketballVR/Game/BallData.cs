using UnityEngine;

namespace BasketballVR.Game
{
    [CreateAssetMenu(menuName = "Ball Data", fileName = "BallData")]
    public class BallData : ScriptableObject
    {
        [field: SerializeField] public Texture2D Texture { get; private set; }
        [field: SerializeField] public int Score { get; private set; }
        [field: SerializeField] public BallPhysicsSettings PhysicsSettings { get; private set; }
    }
}