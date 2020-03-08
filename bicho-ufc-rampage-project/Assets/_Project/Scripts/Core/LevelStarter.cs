
namespace Magrathea.bufcr.Core
{
    using UnityEngine;

    /// <summary>
    /// Componente que verifica quando a fase deve iniciar e notifica o componente responsável 
    /// por propagar a mensagem.
    /// 
    /// Nesse caso quem propaga a mensagem de início da fase para outros componentes é o LevelManager
    /// que guarda um evento OnLevelStart que notifica a lista de interessados..
    /// </summary>
    public class LevelStarter : MonoBehaviour
    {
        private ILevelStarter _levelStarter;//Responsável por propagar que a fase inciou para outros componentes.
        private bool _isLevelStarted = false;//Flag que ajuda a evitar que a mensagem de início da fase seja propagada mais de uma vez.

        private void Awake()
        {
            _levelStarter = FindObjectOfType<LevelManager>();
        }

        private void Update()
        {
            //A fase inicia quando o primeiro input do jogador chega.
            if (Input.anyKeyDown && !_isLevelStarted)
            {
                _levelStarter.StartLevel();
                _isLevelStarted = true;
            }
        }
    }
}