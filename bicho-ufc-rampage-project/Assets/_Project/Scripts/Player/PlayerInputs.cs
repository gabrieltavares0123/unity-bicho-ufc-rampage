using UnityEngine;

namespace Magrathea.BUFCR
{
    public class PlayerInputs : MonoBehaviour, IPlayerInputs
    {
        private bool _alternateKey = false;

        /// <summary>
        /// Verifica se qualquer tecla foi pressionada.
        /// </summary>
        /// <returns>Verdadeira pra qualquer tecla do teclado pressionada.</returns>
        public bool AnyKeyIsPressed()
        {
            return Input.anyKeyDown;
        }

        /// <summary>
        /// Verifica os inputs para o personagem pular.
        /// </summary>
        /// <returns>Verdadeiro caso </returns>
        public bool GetJumpInput()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }

        /// <summary>
        /// Verifica os inputs para mover o personagem para direita.
        /// </summary>
        /// <returns>Verdadeiro caso uma das teclas "d" ou "d" sejam pressionadas.</returns>
        public bool GetMoveInput()
        {
            return AlternateKeys();
        }

        public bool GetDashInput()
        {
            return Input.GetKeyDown(KeyCode.Backspace);
        }

        // Alterna entre as teclas "a" e "d".
        private bool AlternateKeys()
        {
            if (GetAKey())
            {
                _alternateKey = true;
                return true;
            }

            if (GetDKey())
            {
                _alternateKey = false;
                return true;
            }

            return false;
        }

        private bool GetAKey()
        {
            return Input.GetKeyDown(KeyCode.A) && !_alternateKey;
        }

        private bool GetDKey()
        {
            return Input.GetKeyDown(KeyCode.D) && _alternateKey;
        }
    }
}