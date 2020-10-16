using System.Collections.Generic;
using UnityEngine;

namespace Magrathea.BUFCR
{
    [CreateAssetMenu(fileName = "OnPlayerFirstInputEvent", menuName = "BUFCR/Events/OnPlayerFirstInputEvent", order = 1)]
    public class OnPlayerFirstInputEvent : ScriptableObject
    {
        // Lista de ouvintes interessados no evento.
        private List<IPlayerFirstInputListener> listeners = new List<IPlayerFirstInputListener>();

        // Notifica todos os ouvintes do evento.
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnPlayerFirstInput();
        }

        // Adiciona um novo ouvinte interessado no evento.
        public void RegisterListener(IPlayerFirstInputListener listener)
        {
            listeners.Add(listener);
        }

        // Remove um ouvinte.
        public void UnregisterListener(IPlayerFirstInputListener listener)
        {
            listeners.Remove(listener);
        }
    }
}