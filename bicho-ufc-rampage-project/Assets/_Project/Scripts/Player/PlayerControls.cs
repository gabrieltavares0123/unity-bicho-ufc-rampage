using UnityEngine;

namespace Magrathea.BUFCR
{
    /// <summary>
    /// Executa as ações de mover e pular do personagem de acordo com os inputs recebidos do jogador. Esses inputs vem através
    /// da instância de PlayerInputs que é responsável por essa verificação.
    /// </summary>
    [RequireComponent(typeof(PlayerInputs))]
    [RequireComponent(typeof(MoveAction))]
    [RequireComponent(typeof(JumpAction))]
    public class PlayerControls : MonoBehaviour
    {
        private IPlayerInputs _playerInputs;
        private ActionBase _mover;
        private ActionBase _jumper;

        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _mover = GetComponent<MoveAction>();
            _jumper = GetComponent<JumpAction>();
        }

        private void Update()
        {
            // Verifica os inputs do jogador e executa as ações possívei de acordo.
            if (_playerInputs.AnyKeyIsPressed())
            {
                // Realiza o salto do personagem.
                if (_playerInputs.GetJumpInput())
                {
                    _jumper.DoAction();
                }

                // Realiza o movimento para direita do personagem.
                if (_playerInputs.GetMoveInput())
                {
                    _mover.DoAction();
                }
            }
        }

    }
}