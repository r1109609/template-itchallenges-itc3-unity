
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI gewonnenText;
    public GameObject terugNaarStartKnop;

    private int highscore = 0;
    private bool gewonnen = false;

    private void Awake()
    {
        Instance = this;
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void Start()
    {
        UpdateScoreText();

        if (gewonnenText != null)
        {
            gewonnenText.gameObject.SetActive(false);
        }

        if (terugNaarStartKnop != null)
        {
            terugNaarStartKnop.SetActive(false);
        }
    }

    public void AddScore(int punten)
    {
        if (gewonnen) return;

        score += punten;

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }

        UpdateScoreText();

        if (score >= 20)
        {
            WinSpel();
        }
    }

    private void WinSpel()
    {
        gewonnen = true;

        if (gewonnenText != null)
        {
            gewonnenText.gameObject.SetActive(true);
            gewonnenText.text = "GEWONNEN!\nJe hebt 20 munten verzameld!";
        }

        if (terugNaarStartKnop != null)
        {
            terugNaarStartKnop.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void TerugNaarStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + highscore;
        }
    }
}
