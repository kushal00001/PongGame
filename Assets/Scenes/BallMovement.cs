using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.linearVelocity = Vector2.right * speed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce logic for paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleY = collision.transform.position.y;
            float ballY = transform.position.y;

            float diff = ballY - paddleY;
            float bounceAngle = diff / collision.collider.bounds.size.y;

            Vector2 dir = new Vector2(1, bounceAngle).normalized;

            if (transform.position.x < 0)
                dir = new Vector2(1, bounceAngle).normalized;
            else
                dir = new Vector2(-1, bounceAngle).normalized;

            rb.linearVelocity = dir * speed;
        }

        // Reset if ball hits LeftWall
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            ResetBall();
        }
    }
}
