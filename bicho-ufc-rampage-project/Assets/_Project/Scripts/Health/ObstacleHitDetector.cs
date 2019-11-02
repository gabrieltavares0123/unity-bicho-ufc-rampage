
namespace Magrathea.BichoUFCRampage.Health
{
    using UnityEngine;
    using UnityEngine.Events;

    public class ObstacleHitDetector : MonoBehaviour
    {
        public static UnityAction<int> OnHitPlayer;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector2 contactPoint = other.contacts[0].normal;
                Vector2 left = new Vector2(1.0f, 0.0f);
                if (contactPoint == left)
                {
                    OnHitPlayer?.Invoke(Constants.Hit.BOX);
                }
            }
        }
    }
}