
namespace Magrathea.BichoUFCRampage.Inputs
{
    using UnityEngine;

    public class AndroidInput : IInputable
    {
        public bool JumpInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public bool MoveLeftInput()
        {
            return Input.GetKeyDown(KeyCode.A);
        }

        public bool MoveRightInput()
        {
            return Input.GetKeyDown(KeyCode.D);
        }
    }
}