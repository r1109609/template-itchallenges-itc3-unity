using UnityEngine;

public class snelheidsBoost : MonoBehaviour
{
    public float boostSnelheid = 15f;
    public float boostDuur = 5f;

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
            SpelerController speler =
                other.GetComponent<SpelerController>();

            if (speler != null)
            {
                speler.ActiveerSnelheidsboost(
                    boostSnelheid,
                    boostDuur
                );
            }

            Destroy(gameObject);
        }
    }
}
