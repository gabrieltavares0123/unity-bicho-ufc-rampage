
namespace Magrathea.BichoUFCRampage.Dash
{
    using Magrathea.BichoUFCRampage.Score;
    using UnityEngine;

    [RequireComponent(typeof(DashCounterDrawer))]
    public class DashCounter : MonoBehaviour, IDashCounter
    {
        [SerializeField] private int itemCountToUseDash;

        private int _dashCounter;
        private IDrawableDashCounter _dashCounterDrawer;

        private void Awake()
        {
            _dashCounterDrawer = GetComponent<DashCounterDrawer>();
        }

        private void OnEnable()
        {
            ScoreManager.OnItemCollected += IncrementCounter;
        }

        private void OnDisable()
        {
            ScoreManager.OnItemCollected -= IncrementCounter;
        }

        public bool CanDash()
        {
            if (_dashCounter >= itemCountToUseDash)
                return true;
            else
                return false;
        }

        public void IncrementCounter()
        {
            _dashCounter++;
            _dashCounterDrawer.Draw(_dashCounter);
        }

        public void RestartCounter()
        {
            _dashCounter = 0;
            _dashCounterDrawer.Draw(_dashCounter);
        }
    }
}