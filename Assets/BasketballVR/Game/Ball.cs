using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace BasketballVR.Game
{
    public class Ball : MonoBehaviour
    {
        private static readonly int BaseMapPropertyId = Shader.PropertyToID("_BaseMap");
        private static readonly int ColorPropertyId = Shader.PropertyToID("_BaseColor");

        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private XRGrabInteractable _grabInteractable;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private BallCollider _ballCollider;

        private MaterialPropertyBlock _materialPropertyBlock;
        private Transform _currentTransform;
        private Color _defaultColor;
        private Vector3 _defaultPosition;
        public int BallScore { get; private set; }
        public bool IsGrabbed => _grabInteractable.isSelected;
        public SphereCollider Collider => _ballCollider.GetSphereCollider();

        private void Start()
        {
            InitSettingsIfNeeded();
        }

        private void OnEnable()
        {
            _grabInteractable.hoverEntered.AddListener(HandleHoverEntered);
            _grabInteractable.hoverExited.AddListener(HandleHoverExited);
            _grabInteractable.selectEntered.AddListener(HandleSelectExited);
            _grabInteractable.selectExited.AddListener(HandleSelectExited);
        }

        private void OnDisable()
        {
            _grabInteractable.hoverEntered.RemoveListener(HandleHoverEntered);
            _grabInteractable.hoverExited.RemoveListener(HandleHoverExited);
            _grabInteractable.selectEntered.RemoveListener(HandleSelectExited);
            _grabInteractable.selectExited.RemoveListener(HandleSelectExited);
        }

        public void Init(BallData ballData, Vector3 position)
        {
            InitSettingsIfNeeded();
            SetTexture(ballData.Texture);

            _ballCollider.InjectBall(this);
            _ballCollider.InitPhysicsMaterial(ballData.PhysicsSettings.PhysicsMaterial);
            
            BallScore = ballData.Score;
            _rigidbody.mass = ballData.PhysicsSettings.MassRigidbody;
            _rigidbody.linearDamping = ballData.PhysicsSettings.Drag;
            _rigidbody.angularDamping = ballData.PhysicsSettings.AngularDrag;
            
            _defaultPosition = position;
            _currentTransform.position = position;
        }

        public void ResetBall()
        {
            _currentTransform.position = _defaultPosition;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.linearVelocity = Vector3.zero;
        }

        public Vector3 GetVelocity() => _rigidbody.linearVelocity;

        private void InitSettingsIfNeeded()
        {
            if (_currentTransform == null)
            {
                _currentTransform = transform;
            }

            if (_materialPropertyBlock == null)
            {
                _materialPropertyBlock = new MaterialPropertyBlock();
                _meshRenderer.GetPropertyBlock(_materialPropertyBlock);
                _defaultColor = _meshRenderer.sharedMaterial.GetColor(ColorPropertyId);
            }
        }

    

        private void HandleHoverEntered(HoverEnterEventArgs arg0)
        {
            SetColor(Color.green);
        }

        private void HandleHoverExited(HoverExitEventArgs arg0)
        {
            if (!_grabInteractable.isSelected)
            {
                SetColor(_defaultColor);
            }
        }

        private void HandleSelectExited(SelectEnterEventArgs arg0)
        {
            SetColor(Color.yellow);
        }

        private void HandleSelectExited(SelectExitEventArgs arg0)
        {
            SetColor(_defaultColor);
        }

        private void SetColor(Color color)
        {
            _meshRenderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetColor(ColorPropertyId, color);
            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        }

        private void SetTexture(Texture2D ballDataTexture)
        {
            _meshRenderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetTexture(BaseMapPropertyId, ballDataTexture);
            _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}