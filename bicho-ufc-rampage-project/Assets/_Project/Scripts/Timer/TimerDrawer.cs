
namespace Magrathea.bufcr.Timer
{
    using TMPro;
    using UnityEngine;

    public class TimerDrawer : MonoBehaviour, IDrawClock
    {
        [SerializeField] private TextMeshProUGUI timerText;

        public void Draw(float time)
        {
            timerText.text = time.ToString("F3");
        }
    }
}