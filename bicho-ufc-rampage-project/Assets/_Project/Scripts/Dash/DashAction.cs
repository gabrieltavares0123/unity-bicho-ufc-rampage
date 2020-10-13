using System.Collections;
using UnityEngine;

namespace Magrathea.BUFCR
{
    [RequireComponent(typeof(DashCounter))]
    public class DashAction : ActionBase
    {
        [SerializeField] private float dashForce;
        [SerializeField] private float dashDuration;

        private float _dashTimer = 0;
        private IDashCounter _dashCounter;

        protected override void Awake()
        {
            base.Awake();
            _dashCounter = GetComponent<DashCounter>();
        }

        public override void DoAction()
        {
            // Realiza o dash apenas se pelo menos 5 itens foram coletados.
            if (_dashCounter.CanDash())
            {
                // Realiza o dash.
                StopAllCoroutines();
                StartCoroutine(Dashing());
                // Zera o contador.
                _dashCounter.RestartCounter();
            }
        }

        // Realiza o dash pelo tempo determinado.
        private IEnumerator Dashing()
        {
            // Realiza o dash durante o tempo determinado.
            while (_dashTimer <= dashDuration)
            {
                _rigidbody2D.velocity = Vector2.zero;
                Vector2 boostVector = new Vector2(dashForce, 0);
                float timeFactor = Time.deltaTime / dashDuration;
                transform.Translate(boostVector * timeFactor);
                _dashTimer += timeFactor;
                yield return null;
            }

            // Seta os valores padrão após o dash.
            _dashTimer = 0;
            Vector2 endingVelocity = new Vector2(5, -1);
            _rigidbody2D.velocity = endingVelocity;
        }
    }
}