
namespace Magrathea.BichoUFCRampage.JumpPhysics
{
    using UnityEngine;

    [RequireComponent(typeof(RisingSpeedAdjuster))]
    [RequireComponent(typeof(FallingSpeedAdjuster))]
    public class JumpPhysicsCorrector : MonoBehaviour
    {
        [SerializeField] private float risingMultiplier;
        [SerializeField] private float fallingMultiplier;

        private IAdjustableRisingSpeed _risingSpeedCorrector;
        private IAdjustableFallingSpeed _fallingSpeedCorrector;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _risingSpeedCorrector = GetComponent<RisingSpeedAdjuster>();
            _fallingSpeedCorrector = GetComponent<FallingSpeedAdjuster>();

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CorrectGravity();
        }

        private void CorrectGravity()
        {
            if (IsRising())
            {
                _risingSpeedCorrector.GoUpFast(risingMultiplier);
            }

            if (IsFalling())
            {
                _fallingSpeedCorrector.GetDownFast(fallingMultiplier);
            }
        }

        private bool IsRising()
        {
            return _rigidbody2D.velocity.y > 0;
        }

        private bool IsFalling()
        {
            return _rigidbody2D.velocity.y < 0;
        }
    }
}