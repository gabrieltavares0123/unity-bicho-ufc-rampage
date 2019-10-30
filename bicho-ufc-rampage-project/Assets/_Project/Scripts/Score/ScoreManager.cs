
namespace Magrathea.BichoUFCRampage.Score
{
    using UnityEngine;
    using UnityEngine.Events;

    public class ScoreManager : MonoBehaviour, IScoreObserver
    {
        public static UnityAction OnItemCollected;

        private int _score;
        private IDrawableScore _scoreDrawer;

        private void Awake()
        {
            _score = 0;
            _scoreDrawer = FindObjectOfType<ScoreDrawer>();
        }

        private void OnEnable()
        {
            IScoreSubject[] subjects = FindObjectsOfType<ItemBase>();
            foreach (IScoreSubject subject in subjects)
            {
                subject.AttachObserver(this);
            }
        }

        private void OnDisable()
        {
            IScoreSubject[] subjects = FindObjectsOfType<ItemBase>();
            foreach (IScoreSubject subject in subjects)
            {
                subject.DetachObserver(this);
            }
        }

        public void UpdateScore(int points)
        {
            _score += points;
            _scoreDrawer.Draw(_score);
            OnItemCollected();
        }
    }
}