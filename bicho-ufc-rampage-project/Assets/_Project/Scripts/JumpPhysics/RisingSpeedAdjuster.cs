
namespace Magrathea.BichoUFCRampage.JumpPhysics
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class RisingSpeedAdjuster : MonoBehaviour, IAdjustableRisingSpeed
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void GoUpFast(float multiplier)
        {
            Vector2 newVelocity = new Vector2(0, Physics2D.gravity.y * multiplier * Time.fixedDeltaTime);
            _rigidbody2D.velocity += newVelocity;
        }
    }
}