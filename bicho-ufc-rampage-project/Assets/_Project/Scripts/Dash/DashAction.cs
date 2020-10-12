using System.Collections;
using UnityEngine;

namespace Magrathea.BUFCR
{
    public class DashAction : ActionBase, IItemCollectedListener
    {
        [SerializeField] private float dashForce;
        [SerializeField] private float dashDuration;

        private float dashTimer = 0;
        private int _itemCount = 0;

        private const int ITEMS_TO_DASH = 5;

        public override void DoAction()
        {
            // Realiza o dash apenas se pelo menos 5 itens foram coletados.
            if (_itemCount >= ITEMS_TO_DASH)
            {
                // Realiza o dash.
                StopAllCoroutines();
                StartCoroutine(Dashing(dashForce, dashDuration, _rigidbody2D));
                // Zera o contador.
                _itemCount = 0;
            }
        }

        // Realiza o dash pelo tempo determinado.
        private IEnumerator Dashing(float boostForce, float specialDuration, Rigidbody2D rigidbody2D)
        {
            // Realiza o dash durante o tempo determinado.
            while (dashTimer <= specialDuration)
            {
                rigidbody2D.velocity = Vector2.zero;
                Vector2 boostVector = new Vector2(boostForce, 0);
                float timeFactor = Time.deltaTime / specialDuration;
                transform.Translate(boostVector * timeFactor);
                dashTimer += timeFactor;
                yield return null;
            }

            // Seta os valores padrão após o dash.
            dashTimer = 0;
            Vector2 endingVelocity = new Vector2(5, -1);
            rigidbody2D.velocity = endingVelocity;
        }

        // Evento disparado quando um novo item é coletado.
        public void OnItemCollected()
        {
            _itemCount += 1;
        }
    }
}