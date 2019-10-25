
namespace Magrathea.BichoUFCRampage.Controls
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumpper : MonoBehaviour, IJumpable
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void JumpNow(float force)
        {
            float xVel = _rigidbody2D.velocity.x;
            Vector2 newVel = new Vector2(xVel, force);
            _rigidbody2D.velocity = newVel;
        }
    }
}