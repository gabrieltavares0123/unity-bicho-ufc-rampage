
namespace Magrathea.BichoUFCRampage.Health
{
    using UnityEngine;
    using UnityEngine.UI;

    public class HealthDrawer : MonoBehaviour, IDrawableHealth
    {
        [SerializeField] private Slider healthSlider;

        public void DrawHealth(int health)
        {
            healthSlider.value = health;
        }
    }
}