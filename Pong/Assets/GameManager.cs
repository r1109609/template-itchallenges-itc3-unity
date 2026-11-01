
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0;
    public int computerScore = 0;

    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    public void PlayerScores()
    {
        playerScore++;
        UpdateScoreUI();
        Debug.Log("Speler scoort!");
    }

    public void ComputerScores()
    {
        computerScore++;
        UpdateScoreUI();
        Debug.Log("Computer scoort!");
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = computerScore + " - " + playerScore;
        }
    }
}
