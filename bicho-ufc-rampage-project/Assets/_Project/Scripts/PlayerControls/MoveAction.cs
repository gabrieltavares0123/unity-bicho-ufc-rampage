using UnityEngine;

namespace Magrathea.BUFCR
{
    public class MoveAction : ActionBase
    {
        private IGroundChecker _groundChecker;
        [SerializeField] private float movementForce;

        protected override void Awake()
        {
            base.Awake();
            _groundChecker = GetComponent<JumpAction>();
        }

        public override void DoAction()
        {
            // Realiza o movimento para a direita apenas se o personagem estiver em contato com o chão.
            if (_groundChecker.IsGrounded())
            {
                Move();
            }
        }

        // Realiza um movimento para a direita.
        private void Move()
        {
            float ySpeed = _rigidbody2D.velocity.y;
            Vector2 newVel = new Vector2(movementForce, ySpeed);
            _rigidbody2D.velocity = newVel;
        }
    }
}