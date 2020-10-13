using UnityEngine;
using UnityEngine.UI;

namespace Magrathea.BUFCR
{
    public class DashItemCountUI : MonoBehaviour, IDashItemCountUI
    {
        [SerializeField] private Image item0;
        [SerializeField] private Image item1;
        [SerializeField] private Image item2;
        [SerializeField] private Image item3;
        [SerializeField] private Image item4;

        public void SetDashItemCount(int value)
        {
            switch (value)
            {
                case 1:
                    item0.gameObject.SetActive(true);
                    item1.gameObject.SetActive(false);
                    item2.gameObject.SetActive(false);
                    item3.gameObject.SetActive(false);
                    item4.gameObject.SetActive(false);
                    break;
                case 2:
                    item0.gameObject.SetActive(true);
                    item1.gameObject.SetActive(true);
                    item2.gameObject.SetActive(false);
                    item3.gameObject.SetActive(false);
                    item4.gameObject.SetActive(false);
                    break;
                case 3:
                    item0.gameObject.SetActive(true);
                    item1.gameObject.SetActive(true);
                    item2.gameObject.SetActive(true);
                    item3.gameObject.SetActive(false);
                    item4.gameObject.SetActive(false);
                    break;
                case 4:
                    item0.gameObject.SetActive(true);
                    item1.gameObject.SetActive(true);
                    item2.gameObject.SetActive(true);
                    item3.gameObject.SetActive(true);
                    item4.gameObject.SetActive(false);
                    break;
                case 5:
                    item0.gameObject.SetActive(true);
                    item1.gameObject.SetActive(true);
                    item2.gameObject.SetActive(true);
                    item3.gameObject.SetActive(true);
                    item4.gameObject.SetActive(true);
                    break;
                default:
                    item0.gameObject.SetActive(false);
                    item1.gameObject.SetActive(false);
                    item2.gameObject.SetActive(false);
                    item3.gameObject.SetActive(false);
                    item4.gameObject.SetActive(false);
                    break;
            }
        }
    }
}