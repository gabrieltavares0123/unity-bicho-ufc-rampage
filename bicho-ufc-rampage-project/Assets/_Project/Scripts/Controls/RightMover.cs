
namespace Magrathea.BichoUFCRampage.Controls
{
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class RightMover : MonoBehaviour, IMovableRight
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void GoRight(float speed)
        {
            float ySpeed = _rigidbody2D.velocity.y;
            Vector2 newVel = new Vector2(speed, ySpeed);
            _rigidbody2D.velocity = newVel;
        }
    }
}