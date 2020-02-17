
namespace Magrathea.bufcr.Actions.Special
{
    using UnityEngine;
    using UnityEngine.UI;

    public class OnScreenDash : MonoBehaviour, IOnScreenDash
    {
        [SerializeField] private Slider dashCounterSlider;

        public void ShowDashCounterOnScreen(int counter)
        {
            dashCounterSlider.value = counter;
        }
    }
}