﻿
namespace Magrathea.BichoUFCRampage.Controls
{
    using Magrathea.BichoUFCRampage.Inputs;
    using Magrathea.BichoUFCRampage.Dash;
    using UnityEngine;
    using Magrathea.BichoUFCRampage.Health;

    public class ControlsManager : MonoBehaviour, IStopable, IStartable
    {
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
        private bool doINeedToDoMyJob = true;

        private void OnEnable()
        {
            PlayerHealth.OnPlayerDied += StopNow;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerDied -= StopNow;
        }

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

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
            if (doINeedToDoMyJob)
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

        public void StartNow()
        {
            doINeedToDoMyJob = true;
        }

        public void StopNow()
        {
            doINeedToDoMyJob = false;
        }
    }
}