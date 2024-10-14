using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision_Controller : MonoBehaviour
{
    bulletPool bulletPool;

    private void Awake()
    {
        bulletPool = FindAnyObjectByType<bulletPool>();
    }

    void Update()
    {
        if (gameObject.transform.position.y >= 5.4f)
        {
            bulletPool.returnObject(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pinkBall") || collision.CompareTag("redBall") || collision.CompareTag("yellowBall") || collision.CompareTag("greenBall") || collision.CompareTag("blueBall"))
        {
            gameManager.gameManagerInstance.points += 10;
            gameManager.gameManagerInstance.SaveProgress();
            collision.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
            if (collision.gameObject.transform.localScale.x <= 0.3f || collision.gameObject.transform.localScale.y <= 0.3f)
            {
                Destroy(collision.gameObject);
            }
            bulletPool.returnObject(gameObject);
        }
    }
}
