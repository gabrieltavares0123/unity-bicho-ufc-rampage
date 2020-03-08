
namespace Magrathea.bufcr.Core
{
    using UnityEngine;

    /// <summary>
    /// Componente que verifica quando a fase deve finalizar e notifica o componente responsável
    /// por propagar a mensagem.
    /// 
    /// Nesse caso quem propaga a mensagem de fim da fase para outros componentes é o LevelManager
    /// que guarda um evento OnLevelStop que notifica a lista de interessados.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class LevelFinisher : MonoBehaviour
    {
        private ILevelFinisher _levelFinisher;//Responsável por propagar que a fase terminou para outros componentes.

        private void Awake()
        {
            _levelFinisher = FindObjectOfType<LevelManager>();
        }

        /// <summary>
        /// Verifica se o personagem atingil a área de fim da fase para finalizar a fase.
        /// </summary>
        /// <param name="other">Collider que ativa o gatilho.</param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _levelFinisher.FinishLevel();
            }
        }
    }
}