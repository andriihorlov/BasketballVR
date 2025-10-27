using System;
using UnityEngine;

namespace BasketballVR.Game
{
    [Serializable]
    public class BallPhysicsSettings
    {
        [field: SerializeField] public PhysicsMaterial PhysicsMaterial { get; private set; }
        [field: SerializeField] public  float MassRigidbody { get; private set; }
        [field: SerializeField] public float Drag { get; private set; }
        [field: SerializeField] public float AngularDrag { get; private set; }
    }
}