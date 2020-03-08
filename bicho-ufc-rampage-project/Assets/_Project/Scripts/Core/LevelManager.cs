
namespace Magrathea.bufcr.Core
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Componente que propaga a mensagem de início e fim da fase para todos os interessados.
    /// 
    /// Todos os interessados no evento de início da fase estão inscritos no evento OnLevelStart.
    /// Todos os interessados no evento de fim da fase estão inscritos no evento OnStopLevel.
    /// 
    /// Esse componente recebe mensagens de outros componentes como LevelStarter e LevelStopper.
    /// Esses componentes conhecem as regras para que o jogo inicie e finalize respectivamente.
    /// Ou seja, a responsabildiade de verificar a regra de início e fim estão desacopladas desse componente.
    /// </summary>
    public class LevelManager : MonoBehaviour, ILevelStarter, ILevelFinisher
    {
        public static Action OnStartLevel;//Evento para os interessados no início da fase.
        public static Action OnStopLevel;//Evento para os interessados no fim da fase.

        /// <summary>
        /// Notifica todos os interessados no início da fase.
        /// </summary>
        public void StartLevel()
        {
            OnStartLevel();
        }

        /// <summary>
        /// Notifica todos os interessados no fim da fase.
        /// </summary>
        public void StopLevel()
        {
            OnStopLevel();
        }
    }
}