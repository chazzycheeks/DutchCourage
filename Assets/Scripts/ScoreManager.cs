using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    public int score;

    private void Start()
    {
        UpdateHighScoreText();
    }

    public void ResetScore()
    {
        score = 0;
    }
    public void AddScore1()
    {
        score++;
        CheckHighScore();
    }

    public void AddScore2()
    {
        score = score + 2;
        CheckHighScore();
    }

    public void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScoreText();

        }
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";

    }
}
