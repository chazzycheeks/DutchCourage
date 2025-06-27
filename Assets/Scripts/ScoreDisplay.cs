using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    ScoreManager currentScore;

    private void Start()
    {
        currentScore = FindAnyObjectByType<ScoreManager>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        scoreText.text = currentScore.score.ToString();
    }

   
}
