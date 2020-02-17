
namespace Magrathea.bufcr.Actions
{
    using UnityEngine;

    public class GroundChecker : MonoBehaviour, IGroundable
    {
        public bool IsGrounded(LayerMask layer, Transform left, Transform right)
        {
            return Physics2D.OverlapArea(left.position, right.position, layer);
        }
    }
}