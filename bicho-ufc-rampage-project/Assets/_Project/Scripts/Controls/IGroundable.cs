
using UnityEngine;

namespace Magrathea.BichoUFCRampage.Controls
{
    public interface IGroundable
    {
        bool IsGrounded(LayerMask layer, Transform left, Transform right);
    }
}