
namespace Magrathea.bufcr.Actions
{
    using UnityEngine;

    using Magrathea.BichoUFCRampage.Inputs;

    [RequireComponent(typeof(InputManager))]
    [RequireComponent(typeof(GroundChecker))]
    public class Jumpper : ActionsBase
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform leftChecker;
        [SerializeField] private Transform rightChecker;

        private IInputManager _inputManager;
        private IGroundable _groundChecker;

        protected override void Awake()
        {
            base.Awake();
            _inputManager = GetComponent<InputManager>();
            _groundChecker = GetComponent<GroundChecker>();
        }

        protected override bool CanDoAction()
        {
            return _inputManager.Inputs.JumpInput() && CanJump();
        }

        private bool CanJump()
        {
            return _inputManager.Inputs.JumpInput() &&
                _groundChecker.IsGrounded(groundLayer, leftChecker, rightChecker);
        }

        protected override void DoAction()
        {
            float xVel = _rigidbody2D.velocity.x;
            Vector2 newVel = new Vector2(xVel, jumpForce);
            _rigidbody2D.velocity = newVel;
        }
    }
}