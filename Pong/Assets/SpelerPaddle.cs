using UnityEngine;
using UnityEngine.InputSystem;

public class SpelerPaddle : MonoBehaviour
{
    public float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        float movement = 0f;

        // als het pijlje omhoog wordt gekliky dan gaat het omlaag
        if (Keyboard.current.upArrowKey.isPressed)
        {
            movement = 1f;
        }

        // als het pijlje omlaag wordt geklikt dan gaat het omlaag
        if (Keyboard.current.downArrowKey.isPressed)
        {
            movement = -1f;
        }

        // Beweeg de paddle alleen omhoog of omlaag
        transform.Translate(Vector2.up * movement * speed * Time.deltaTime);
    }
}


