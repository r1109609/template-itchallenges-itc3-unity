
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 5f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 12f;

    private Rigidbody2D rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        // Stop de bal en plaats hem in het midden
        rb.linearVelocity = Vector2.zero;
        rb.position = Vector2.zero;

        // Beginsnelheid herstellen
        currentSpeed = startSpeed;

        // Willekeurige richting naar links of rechts
        float xDirection = Random.value < 0.5f ? -1f : 1f;

        // Willekeurige verticale richting
        float yDirection = Random.Range(-0.8f, 0.8f);

        Vector2 direction =
            new Vector2(xDirection, yDirection).normalized;

        // Bal opnieuw laten vertrekken
        rb.linearVelocity = direction * currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Versnellen wanneer de bal een paddle raakt
        if (collision.gameObject.name == "PlayerPaddle" ||
            collision.gameObject.name == "ComputerPaddle")
        {
            currentSpeed += speedIncrease;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            rb.linearVelocity =
                rb.linearVelocity.normalized * currentSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameManager gameManager =
            FindFirstObjectByType<GameManager>();

        if (other.gameObject.name == "LinkerGoal")
        {
            gameManager.PlayerScores();
            LaunchBall();
        }
        else if (other.gameObject.name == "RechterGoal")
        {
            gameManager.ComputerScores();
            LaunchBall();
        }
    }
}
