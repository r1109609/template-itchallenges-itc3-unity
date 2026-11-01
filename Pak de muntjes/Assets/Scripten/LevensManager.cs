using TMPro;
using UnityEngine;

public class LevensManager : MonoBehaviour
{
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject highscoreTekst;

    private bool shieldActive = false;

    private void Start()
    {
        UpdateLivesText();

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        if (highscoreTekst != null)
            highscoreTekst.SetActive(false);
    }

    public void ActivateShield()
    {
        shieldActive = true;
        Debug.Log("Schild geactiveerd!");
    }

    public void LoseLife()
    {
        if (shieldActive)
        {
            shieldActive = false;
            Debug.Log("Schild heeft de steen tegengehouden!");
            return;
        }

        if (lives <= 0) return;

        lives--;
        UpdateLivesText();

        Debug.Log("Levens over: " + lives);

        if (lives <= 0)
        {
            if (gameOverText != null)
                gameOverText.SetActive(true);

            if (restartButton != null)
                restartButton.SetActive(true);

            if (highscoreTekst != null)
                highscoreTekst.SetActive(true);

            Time.timeScale = 0f;
            Debug.Log("GAME OVER!");
        }
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
            livesText.text = "Levens: " + lives;
    }
}
