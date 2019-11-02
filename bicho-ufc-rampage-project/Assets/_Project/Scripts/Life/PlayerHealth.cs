
namespace Magrathea.BichoUFCRampage.Health
{
    using UnityEngine;

    [RequireComponent(typeof(HealthDrawer))]
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int startingHealth;

        private int _health;
        private IDrawableHealth _healthDrawer;

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
            _healthDrawer = GetComponent<HealthDrawer>();
        }

        public void Decrement(int value)
        {
            if (IsAlive())
            {
                _health -= value;
                _healthDrawer.DrawHealth(_health);

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
            _healthDrawer.DrawHealth(_health);
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