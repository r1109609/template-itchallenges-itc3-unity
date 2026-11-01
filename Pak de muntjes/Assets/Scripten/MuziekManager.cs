using UnityEngine;

public class MuziekManager : MonoBehaviour
{
    private static MuziekManager instantie;

    private void Awake()
    {
        if (instantie != null && instantie != this)
        {
            Destroy(gameObject);
            return;
        }

        instantie = this;
        DontDestroyOnLoad(gameObject);
    }
}