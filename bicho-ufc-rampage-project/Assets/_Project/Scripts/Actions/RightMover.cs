
namespace Magrathea.bufcr.Actions
{
    using UnityEngine;

    using Magrathea.BichoUFCRampage.Inputs;

    [RequireComponent(typeof(InputManager))]
    public class RightMover : ActionsBase
    {
        [SerializeField] private float movementForce;

        private IInputManager _inputManager;

        protected override void Awake()
        {
            base.Awake();
            _inputManager = GetComponent<InputManager>();
        }

        protected override bool CanDoAction()
        {
            return _inputManager.Inputs.MoveInput();
        }

        protected override void DoAction()
        {
            float ySpeed = _rigidbody2D.velocity.y;
            Vector2 newVel = new Vector2(movementForce, ySpeed);
            _rigidbody2D.velocity = newVel;
        }
    }
}