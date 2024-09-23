using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGenerator_Controller : MonoBehaviour
{
    [SerializeField] GameObject cannon;
    [SerializeField] GameObject bullet;
    float bulletSpeed = 20f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 position = new Vector2((cannon.transform.position.x - 0.06f), (cannon.transform.position.y + 0.4f));
            GameObject newBullet = Instantiate(bullet, position, Quaternion.identity);

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0, bulletSpeed); 
            }
        }
    }
}
