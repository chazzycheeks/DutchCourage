using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    public int score;
    public GameObject mainGame;
    public GameObject endScreen;

    private void Start()
    {
        UpdateHighScoreText();
        mainGame.SetActive(true);
        endScreen.SetActive(false);
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

    public void GameOver()
    {
        mainGame.SetActive(false);
        endScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
