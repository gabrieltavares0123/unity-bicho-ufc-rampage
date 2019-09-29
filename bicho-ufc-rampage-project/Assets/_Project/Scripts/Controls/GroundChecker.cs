
namespace Magrathea.BichoUFCRampage.Controls
{
    using UnityEngine;

    public class GroundChecker : MonoBehaviour, IGroundable
    {
        public LayerMask Layer
        {
            get;
            set;
        }

        public Transform LeftChecker
        {
            get;
            set;
        }
        public Transform RightChecker
        {
            get;
            set;
        }

        public bool IsGrounded()
        {
            return Physics2D.OverlapArea(LeftChecker.position, RightChecker.position, Layer);
        }
    }
}