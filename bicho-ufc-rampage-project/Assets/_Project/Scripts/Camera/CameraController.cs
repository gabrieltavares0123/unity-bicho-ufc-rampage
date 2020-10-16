using UnityEngine;

namespace Magrathea.BUFCR
{
    public class CameraController : MonoBehaviour, IPlayerFirstInputListener
    {
        [SerializeField] private OnPlayerFirstInputEvent onPlayerFirstInputEvent;
        [SerializeField] private float cameraSpeed;
        [SerializeField] private Transform player;

        private bool _isPlayerFirstInputPressed = false;

        private void OnEnable()
        {
            onPlayerFirstInputEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            onPlayerFirstInputEvent.UnregisterListener(this);
        }

        private void Update()
        {
            // Só move a câmera depois do primero input do jogador.
            if (_isPlayerFirstInputPressed)
            {
                // Ajusta a câmera caso o personagem esteja à frente da câmera.
                if (IsPLayerAheadCamera())
                {
                    CenterCamera();
                }
                // Move a câmera para direita.
                else
                {
                    MoveRight();
                }
            }
        }

        // Verdadeiro caso o personagem esteja a frente da câmera.
        private bool IsPLayerAheadCamera()
        {
            return player.position.x - 2f > transform.position.x;
        }

        // Ajusta a câmera em relação ao personagem.
        private void CenterCamera()
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                new Vector3(player.position.x, transform.position.y, transform.position.z), .1f);
        }

        // Move a câmera para direita em velocidade constante.
        private void MoveRight()
        {
            transform.Translate(cameraSpeed * Time.deltaTime, 0, 0);
        }

        // Evento do primeiro input do jogador.
        public void OnPlayerFirstInput()
        {
            _isPlayerFirstInputPressed = true;
        }
    }
}
