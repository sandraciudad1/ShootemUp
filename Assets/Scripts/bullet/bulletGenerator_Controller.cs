using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGenerator_Controller : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    static float bulletSpeed = 20f;
    Vector3 cannonPosition;

    [SerializeField] bulletPool bulletPool;

    void Update()
    {
        if (cannonMovement_Controller.cannonInstance != null)
        {
            cannonPosition = cannonMovement_Controller.cannonInstance.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 position = new Vector2((cannonPosition.x - 0.06f), (cannonPosition.y + 0.4f));
            GameObject newBullet = bulletPool.getObject();
            newBullet.transform.position = position;

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0, bulletSpeed); 
            }
        }
    }
}
