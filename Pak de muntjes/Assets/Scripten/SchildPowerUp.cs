using UnityEngine;

public class SchildPowerUp : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevensManager lifeManager =
                FindAnyObjectByType<LevensManager>();

            if (lifeManager != null)
            {
                lifeManager.ActivateShield();
            }

            Destroy(gameObject);
        }
    }
}
