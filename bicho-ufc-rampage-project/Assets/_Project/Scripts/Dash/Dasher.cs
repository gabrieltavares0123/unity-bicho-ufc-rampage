
namespace Magrathea.BichoUFCRampage.Dash
{
    using System.Collections;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(DashCounter))]
    public class Dasher : MonoBehaviour, IDashable
    {
        private Rigidbody2D _rigidbody2D;

        private IDashCounter _dashCounter;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _dashCounter = GetComponent<DashCounter>();
        }

        public void DoDash(float boost, float duration)
        {
            if (_dashCounter.CanDash())
            {
                StopAllCoroutines();
                StartCoroutine(Dashing(boost, duration, _rigidbody2D));
                _dashCounter.RestartCounter();
            }
        }

        private float dashTimer = 0;
        private IEnumerator Dashing(float boost, float duration, Rigidbody2D rigidbody2D)
        {
            while (dashTimer <= duration)
            {
                rigidbody2D.velocity = Vector2.zero;
                Vector2 boostVector = new Vector2(boost, 0);
                float timeFactor = Time.deltaTime / duration;
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