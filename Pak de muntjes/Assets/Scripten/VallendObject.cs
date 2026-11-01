using UnityEngine;

public class VallendObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevensManager lifeManager =
                FindFirstObjectByType<LevensManager>();

            if (lifeManager != null)
            {
                lifeManager.LoseLife();
            }

            Destroy(gameObject);
        }
    }
}
