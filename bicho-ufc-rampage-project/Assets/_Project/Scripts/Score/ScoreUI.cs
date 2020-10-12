using UnityEngine;
using TMPro;

namespace Magrathea.BUFCR
{
    public class ScoreUI : MonoBehaviour, IShowTextUI
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void ShowText(string text)
        {
            scoreText.SetText(text);
        }
    }
}