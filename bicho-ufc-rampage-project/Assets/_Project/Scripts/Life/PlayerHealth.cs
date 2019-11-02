
namespace Magrathea.BichoUFCRampage.Health
{
    using UnityEngine;

    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int startingHealth;

        private int _health;

        private void OnEnable()
        {
            ObstacleHitDetector.OnHitPlayer += Decrement;
        }

        private void OnDisable()
        {
            ObstacleHitDetector.OnHitPlayer -= Decrement;
        }

        private void Awake()
        {
            _health = startingHealth;
        }

        public void Decrement(int value)
        {
            if (IsAlive())
            {
                _health -= value;

                if (!IsAlive())
                {
                    DieNow();
                }
            }
        }

        private bool IsAlive()
        {
            return _health > 0;
        }

        private void DieNow()
        {
            _health = 0;
            Debug.Log("You have died.");
        }

        private void OnBecameInvisible()
        {
            if (IsAlive())
            {
                DieNow();
            }
        }
    }
}