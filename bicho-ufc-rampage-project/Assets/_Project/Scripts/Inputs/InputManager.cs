
namespace Magrathea.BichoUFCRampage.Inputs
{
    using UnityEngine;

    public class InputManager : MonoBehaviour, IInputManager
    {
        public IInputable Inputs
        {
            private set => _inputs = value;
            get => _inputs;
        }

        private IInputable _inputs;

        private void Awake()
        {
#if UNITY_STANDALONE
            Inputs = new PCInput();
#elif UNITY_ANDROID
            Inputs = new AndroidInput();
#endif
        }
    }
}