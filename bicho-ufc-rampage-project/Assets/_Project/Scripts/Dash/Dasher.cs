
namespace Magrathea.BichoUFCRampage.Dash
{
    using System.Collections;
    using UnityEngine;

    public class Dasher : MonoBehaviour, IDashable
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void DoDash(float boost, float duration)
        {
            StopAllCoroutines();
            StartCoroutine(Dashing(boost, duration, _rigidbody2D));
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