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
    [RequireComponent(typeof(DashAction))]
    public class PlayerControls : MonoBehaviour
    {
        private IPlayerInputs _playerInputs;
        private ActionBase _mover;
        private ActionBase _jumper;
        private ActionBase _dasher;

        private void Awake()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _mover = GetComponent<MoveAction>();
            _jumper = GetComponent<JumpAction>();
            _dasher = GetComponent<DashAction>();
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

                // Realiza o dash do personagem.
                if (_playerInputs.GetDashInput())
                {
                    _dasher.DoAction();
                }
            }
        }

    }
}