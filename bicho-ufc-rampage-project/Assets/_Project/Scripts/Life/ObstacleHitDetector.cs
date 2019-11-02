
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
                OnHitPlayer?.Invoke(Constants.Hit.BOX);
            }
        }
    }
}