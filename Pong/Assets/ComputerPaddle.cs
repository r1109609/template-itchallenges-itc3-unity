using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    public Transform ball;
    public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (ball == null)
            return;

        float direction = 0f;

        if (ball.position.y > transform.position.y)
        {
            direction = 1f;
        }
        else if (ball.position.y < transform.position.y)
        {
            direction = -1f;
        }

        rb.linearVelocity = new Vector2(0f, direction * speed);
    }
}
