
namespace Magrathea.BichoUFCRampage.Score
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class ItemBase : MonoBehaviour, IScoreSubject
    {
        protected List<IScoreObserver> observers = new List<IScoreObserver>();

        public void AttachObserver(IScoreObserver observer)
        {
            observers.Add(observer);
        }

        public void DetachObserver(IScoreObserver observer)
        {
            observers.Remove(observer);
        }

        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}