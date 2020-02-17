
using UnityEngine;

namespace Magrathea.bufcr.Actions
{
    public interface IGroundable
    {
        bool IsGrounded(LayerMask layer, Transform left, Transform right);
    }
}