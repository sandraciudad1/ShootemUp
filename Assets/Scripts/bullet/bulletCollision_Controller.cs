using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision_Controller : MonoBehaviour
{
    int points;
    
    void Start()
    {
        points = PlayerPrefs.GetInt("points", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y >= 5.4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pinkBall") || collision.CompareTag("redBall") || collision.CompareTag("yellowBall") || collision.CompareTag("greenBall") || collision.CompareTag("blueBall"))
        {
            points += 10;
            PlayerPrefs.SetInt("points", points);
            collision.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
            if (collision.gameObject.transform.localScale.x <= 0.3f || collision.gameObject.transform.localScale.y <= 0.3f)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
