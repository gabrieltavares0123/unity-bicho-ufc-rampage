using UnityEngine;

namespace Magrathea.BUFCR
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private OnItemCollectedEvent onItemCollectedEvent;
        [SerializeField] private int score = 100;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onItemCollectedEvent.Raise(score);
                gameObject.SetActive(false);
            }
        }
    }
}