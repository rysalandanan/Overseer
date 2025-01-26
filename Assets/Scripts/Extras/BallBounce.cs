using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float initialSpeed; // Set the initial speed of the ball
    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        // Launch the ball in a random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;  // Random direction
        rb.velocity = randomDirection * initialSpeed; // Apply initial speed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Maintain constant speed after collision
        rb.velocity = rb.velocity.normalized * initialSpeed;
    }
}
