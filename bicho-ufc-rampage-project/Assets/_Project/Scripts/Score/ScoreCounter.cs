using UnityEngine;

namespace Magrathea.BUFCR
{
    [RequireComponent(typeof(ScoreUI))]
    public class ScoreCounter : MonoBehaviour, IItemCollectedListener
    {
        [SerializeField] private IShowTextUI scoreUI;
        [SerializeField] private OnItemCollectedEvent onItemCollectedEvent;

        private int _totalScore = 0;

        private void Awake()
        {
            scoreUI = GetComponent<ScoreUI>();
        }

        private void OnEnable()
        {
            onItemCollectedEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            onItemCollectedEvent.UnregisterListener(this);
        }

        public void OnItemCollected(int value)
        {
            _totalScore += value;
            scoreUI.ShowText(_totalScore.ToString());
        }
    }
}