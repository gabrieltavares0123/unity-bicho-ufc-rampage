
namespace Magrathea.bufcr.Actions.Special
{
    using UnityEngine;

    using Magrathea.BichoUFCRampage.Score;

    [RequireComponent(typeof(OnScreenDash))]
    public class DashController : MonoBehaviour, IDashController
    {
        [SerializeField] private int itemCountToUseDash;

        private int _dashCounter;
        private IOnScreenDash _onScreenDash;

        private void Awake()
        {
            _onScreenDash = GetComponent<OnScreenDash>();
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
            _onScreenDash.ShowDashCounterOnScreen(_dashCounter);
        }

        public void RestartCounter()
        {
            _dashCounter = 0;
            _onScreenDash.ShowDashCounterOnScreen(_dashCounter);
        }
    }
}