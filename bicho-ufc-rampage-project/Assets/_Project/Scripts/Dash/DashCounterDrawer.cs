
namespace Magrathea.BichoUFCRampage.Dash
{
    using UnityEngine;
    using UnityEngine.UI;

    public class DashCounterDrawer : MonoBehaviour, IDrawableDashCounter
    {
        [SerializeField] private Slider dashCounterSlider;

        public void Draw(int counter)
        {
            dashCounterSlider.value = counter;
        }
    }
}