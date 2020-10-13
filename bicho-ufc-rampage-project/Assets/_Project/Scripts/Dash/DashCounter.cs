using UnityEngine;

namespace Magrathea.BUFCR
{
    [RequireComponent(typeof(DashItemCountUI))]
    public class DashCounter : MonoBehaviour, IDashCounter, IItemCollectedListener
    {
        [SerializeField] private OnItemCollectedEvent onItemCollectedEvent;

        private IDashItemCountUI _dashUI;
        private int _itemCount = 0;
        private const int ITEMS_TO_DASH = 5;

        private void OnEnable()
        {
            onItemCollectedEvent.RegisterListener(this);
        }

        private void Awake()
        {
            _dashUI = GetComponent<DashItemCountUI>();
        }

        private void OnDisable()
        {
            onItemCollectedEvent.UnregisterListener(this);
        }

        private void Start()
        {
            _dashUI.SetDashItemCount(_itemCount);
        }

        public bool CanDash()
        {
            return _itemCount >= ITEMS_TO_DASH;
        }

        public void RestartCounter()
        {
            _itemCount = 0;
            _dashUI.SetDashItemCount(_itemCount);
        }

        public void OnItemCollected(int value)
        {
            _itemCount += 1;
            _dashUI.SetDashItemCount(_itemCount);
        }
    }
}