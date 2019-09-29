
using UnityEngine;

namespace Magrathea.BichoUFCRampage.Controls
{
    public interface IGroundable
    {
        LayerMask Layer { get; set; }
        Transform LeftChecker { get; set; }
        Transform RightChecker { get; set; }
        bool IsGrounded();
    }
}