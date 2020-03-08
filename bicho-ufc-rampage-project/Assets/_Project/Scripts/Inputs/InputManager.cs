
namespace Magrathea.BichoUFCRampage.Inputs
{
    using UnityEngine;

    public class InputManager : MonoBehaviour, IInputManager
    {
        public IInputable Inputs
        {
            private set;
            get;
        }

        private void Awake()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            GameObject inputGameObject = new GameObject("PC Input");
            inputGameObject.transform.parent = gameObject.transform;
            Inputs = inputGameObject.AddComponent<PCInput>();
#elif UNITY_ANDROID
            GameObject inputGameObject = new GameObject("Android Input");
            inputGameObject.transform.parent = gameObject.transform;
            Inputs = inputGameObject.AddComponent<AndroidInput>();
#endif
        }
    }
}