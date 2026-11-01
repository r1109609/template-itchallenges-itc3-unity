using UnityEngine;
using UnityEngine.SceneManagement;

public class MoeilijkheidsKeuze : MonoBehaviour
{
    public void StartMakkelijk()
    {
        PlayerPrefs.SetInt("Moeilijkheid", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
    }

    public void StartMoeilijk()
    {
        PlayerPrefs.SetInt("Moeilijkheid", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
    }
}