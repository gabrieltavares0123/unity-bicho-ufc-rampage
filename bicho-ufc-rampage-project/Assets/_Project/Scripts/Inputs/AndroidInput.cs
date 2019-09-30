
namespace Magrathea.BichoUFCRampage.Inputs
{
    using UnityEngine;

    public class AndroidInput : IInputable
    {
        public bool DashInput()
        {
            throw new System.NotImplementedException();
        }

        public bool JumpInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public bool MoveInput()
        {
            return Input.GetKeyDown(KeyCode.D);
        }
    }
}