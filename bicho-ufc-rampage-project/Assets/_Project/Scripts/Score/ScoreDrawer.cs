
namespace Magrathea.BichoUFCRampage.Score
{
    using UnityEngine;
    using TMPro;

    public class ScoreDrawer : MonoBehaviour, IDrawableScore
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void Draw(int score)
        {
            scoreText.SetText(score.ToString());
        }
    }
}