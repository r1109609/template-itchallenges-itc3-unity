
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;

        // Verwijder alle coins en rocks in de scène
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Munt");
        foreach (GameObject coin in coins)
        {
            Destroy(coin);
        }

        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Steen");
        foreach (GameObject rock in rocks)
        {
            Destroy(rock);
        }

        // Herlaad de huidige scène
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    private void OnDestroy()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveListener(RestartGame);
        }
    }
}
