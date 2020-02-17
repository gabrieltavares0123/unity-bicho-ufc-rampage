
namespace Magrathea.bufcr.Actions.Special
{
    using System.Collections;
    using UnityEngine;

    using Magrathea.BichoUFCRampage.Inputs;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(InputManager))]
    [RequireComponent(typeof(DashController))]
    public class Dasher : ActionsBase
    {
        [SerializeField] private float boostForce;
        [SerializeField] private float specialDuration;

        private IInputManager _inputManager;
        private IDashController _dashController;

        protected override void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _inputManager = GetComponent<InputManager>();
            _dashController = GetComponent<DashController>();
        }

        
        protected override bool CanDoAction()
        {
            return _inputManager.Inputs.DashInput() && _dashController.CanDash();
        }

        protected override void DoAction()
        {
            StopAllCoroutines();
            StartCoroutine(Dashing(boostForce, specialDuration, _rigidbody2D));
            _dashController.RestartCounter();
        }

        private float dashTimer = 0;
        private IEnumerator Dashing(float boostForce, float specialDuration, Rigidbody2D rigidbody2D)
        {
            while (dashTimer <= specialDuration)
            {
                rigidbody2D.velocity = Vector2.zero;
                Vector2 boostVector = new Vector2(boostForce, 0);
                float timeFactor = Time.deltaTime / specialDuration;
                transform.Translate(boostVector * timeFactor);
                dashTimer += timeFactor;
                yield return null;
            }

            dashTimer = 0;
            Vector2 endingVelocity = new Vector2(5, -1);
            rigidbody2D.velocity = endingVelocity;
        }
    }
}