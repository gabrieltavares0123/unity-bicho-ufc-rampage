
namespace Magrathea.BichoUFCRampage.Score
{
    using UnityEngine;

    public class ItemBeer : ItemBase
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                foreach (IScoreObserver observer in observers)
                {
                    observer.UpdateScore(Constants.Itens.BEER);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
