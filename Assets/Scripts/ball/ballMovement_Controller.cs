using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 actualVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        actualVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            Vector2 invertedVelocity = new Vector2(actualVelocity.x, -actualVelocity.y);
            rb.velocity = invertedVelocity;
        } else if (collision.gameObject.CompareTag("walls"))
        {
            Vector2 invertedVelocity = new Vector2(-actualVelocity.x, actualVelocity.y);
            rb.velocity = invertedVelocity;
        }
    }
}
