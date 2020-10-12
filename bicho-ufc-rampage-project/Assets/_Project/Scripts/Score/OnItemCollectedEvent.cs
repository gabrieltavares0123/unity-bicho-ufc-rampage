using System.Collections.Generic;
using UnityEngine;

namespace Magrathea.BUFCR
{
    [CreateAssetMenu(fileName = "OnItemCollectedEvent", menuName = "BUFCR/Events/OnItemCollectedEvent", order = 0)]
    public class OnItemCollectedEvent : ScriptableObject
    {
        // Lista de ouvintes interessados no evento.
        private List<IItemCollectedListener> listeners = new List<IItemCollectedListener>();

        // Notifica todos os ouvintes do evento.
        public void Raise(int value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnItemCollected(value);
        }

        // Adiciona um novo ouvinte interessado no evento.
        public void RegisterListener(IItemCollectedListener listener)
        {
            listeners.Add(listener);
        }

        // Remove um ouvinte.
        public void UnregisterListener(IItemCollectedListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
