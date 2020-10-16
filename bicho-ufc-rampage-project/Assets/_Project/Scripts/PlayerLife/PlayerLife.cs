using UnityEngine;

namespace Magrathea.BUFCR
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField] private GameObject endGameScreen;

        private void Awake()
        {
            endGameScreen.SetActive(false);
        }

        private void OnBecameInvisible()
        {
            endGameScreen.SetActive(true);
        }
    }
}