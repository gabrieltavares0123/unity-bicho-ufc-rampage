
namespace Magrathea.BichoUFCRampage.Inputs
{
    using UnityEngine;
    public class PCInput : IInputable
    {
        public bool JumpInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        public bool MoveInput()
        {
            return AlternateButtons();
        }

        public bool DashInput()
        {
            throw new System.NotImplementedException();
        }

        private bool alternate = false;
        private bool AlternateButtons()
        {
            if (GetAButton() && !alternate)
            {
                alternate = true;
                return true;
            }

            if (GetDButton() && alternate)
            {
                alternate = false;
                return true;
            }

            return false;
        }

        private bool GetAButton()
        {
            return Input.GetKeyDown(KeyCode.A);
        }

        private bool GetDButton()
        {
            return Input.GetKeyDown(KeyCode.D);
        }
    }
}