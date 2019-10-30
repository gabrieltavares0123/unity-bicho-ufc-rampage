
namespace Magrathea.BichoUFCRampage.Controls
{
    using System;
    using Magrathea.BichoUFCRampage.Inputs;
    using Magrathea.BichoUFCRampage.Dash;
    using UnityEngine;
    using UnityEngine.UI;

    public class ControlsManager : MonoBehaviour
    {
        public ControleDeScore controladorDeScore;
        public Text textoDash;

        private bool proxBotao = true;
        private bool parar = false;
        private bool dash = false;

        [SerializeField] private float rightSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform leftChecker;
        [SerializeField] private Transform rightChecker;
        [SerializeField] private float dashBoost;
        [SerializeField] private float dashDuration;

        private IMovableRight _rightMover;
        private IJumpable _jumpper;
        private IGroundable _groundChecker;
        private IInputManager _inputManager;
        private IDashable _dasher;

        private Rigidbody2D _rigidbody;
        private Animator _animator;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            textoDash.enabled = false;

            _rightMover = GetComponent<RightMover>();
            _jumpper = GetComponent<Jumpper>();
            _groundChecker = GetComponent<GroundChecker>();
            _inputManager = GetComponent<InputManager>();
            _dasher = GetComponent<Dasher>();
        }

        void Update()
        {
            _animator.SetFloat("Correndo", Mathf.Abs(_rigidbody.velocity.x));

            VerifyInputs();
        }

        private void VerifyInputs()
        {
            if (CanMoveRight())
            {
                _rightMover.GoRight(rightSpeed);
            }

            if (CanJump())
            {
                _jumpper.JumpNow(jumpForce);
            }

            if (_inputManager.Inputs.DashInput())
            {
                
                _dasher.DoDash((dashBoost * rightSpeed), dashDuration);
            }
        }

        private bool CanMoveRight()
        {
            return _inputManager.Inputs.MoveInput() && 
                _groundChecker.IsGrounded(groundLayer, leftChecker, rightChecker);
        }

        private bool CanJump()
        {
            return _inputManager.Inputs.JumpInput() && 
                _groundChecker.IsGrounded(groundLayer, leftChecker, rightChecker);
        }

        void Dash()
        {
            this.dash = true;
            textoDash.enabled = dash;
            Debug.Log("Dash habilitado");
        }

        void Parar()
        {
            this.parar = true;
            textoDash.enabled = false;
        }

        void Bater()
        {
            this._animator.SetTrigger("Bater");
            Vector3 vx = Vector3.zero;
            this._rigidbody.velocity = vx;
            //vx.x = -velocidadePersonagem.x;
            this._rigidbody.velocity = vx;
        }
    }
}