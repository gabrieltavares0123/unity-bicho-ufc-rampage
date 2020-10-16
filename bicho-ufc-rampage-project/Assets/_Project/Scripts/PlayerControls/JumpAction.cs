using UnityEngine;

namespace Magrathea.BUFCR
{
    public class JumpAction : ActionBase, IGroundChecker
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform leftChecker;
        [SerializeField] private Transform rightChecker;

        [SerializeField] private float risingMultiplier;
        [SerializeField] private float fallingMultiplier;

        private void Update()
        {
            // Realiza as correções da velocidade de subida e descida do salto.
            CorrectJump();
        }

        public override void DoAction()
        {
            // Só realiza o salto se o personagem estiver em contato com o chão.
            if (IsGrounded())
            {
                Jump();
            }
        }

        // Realiza o salto do personagem.
        private void Jump()
        {
            float xVel = _rigidbody2D.velocity.x;
            Vector2 newVel = new Vector2(xVel, jumpForce);
            _rigidbody2D.velocity = newVel;
        }

        /// <summary>
        /// Verifica se o personagem está em contato com o chão.
        /// </summary>
        /// <returns>Verdadeira caso esteja em contato com o chão. Faso caso contrário.</returns>
        public bool IsGrounded()
        {
            return Physics2D.OverlapArea(leftChecker.position, rightChecker.position, groundLayer);
        }

        // Realiza os ajustes na velodidade de subida e descida do salto do personagem.
        private void CorrectJump()
        {
            if (IsRising())
            {
                GoUpFast();
            }

            if (IsFalling())
            {
                GetDownFast();
            }
        }

        // Verifica se o personagem está caindo.
        private bool IsRising()
        {
            return _rigidbody2D.velocity.y > 0;
        }

        // Verifica se o personagem está iniciando o salto.
        private bool IsFalling()
        {
            return _rigidbody2D.velocity.y < 0;
        }

        // Acelera o início do salto fazendo o persongem chegar na altura máxima rápido.
        private void GoUpFast()
        {
            Vector2 newVelocity = new Vector2(0, Physics2D.gravity.y * risingMultiplier * Time.fixedDeltaTime);
            _rigidbody2D.velocity += newVelocity;
        }

        // Acelera a fase de descida do salto fazendo o personagem chegar rápido no chão.
        private void GetDownFast()
        {
            Vector2 newVelocity = new Vector2(0, Physics2D.gravity.y * fallingMultiplier * Time.fixedDeltaTime);
            _rigidbody2D.velocity += newVelocity;
        }
    }
}