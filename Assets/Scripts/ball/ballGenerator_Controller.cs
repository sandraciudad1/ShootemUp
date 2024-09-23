using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballGenerator_Controller : MonoBehaviour
{
    [SerializeField] GameObject pinkBall;
    [SerializeField] GameObject redBall;
    [SerializeField] GameObject yellowBall;
    [SerializeField] GameObject blueBall;
    [SerializeField] GameObject greenBall;
    public GameObject[] objectsArray;

    float spawnInterval = 12f;
    float horizontalForceRange = 5f;
    int ballCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnRandomBall", 0f, spawnInterval);
    }

    public void SpawnRandomBall()
    {
        int randomIndex = Random.Range(0, objectsArray.Length);
        GameObject ballToSpawn = objectsArray[randomIndex];
        Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(4.6f, 4.65f));

        GameObject spawnedBall = Instantiate(ballToSpawn, randomPosition, Quaternion.identity);
        Rigidbody2D rb = spawnedBall.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float randomHorizontalForce = Random.Range(-horizontalForceRange, horizontalForceRange);
            rb.AddForce(new Vector2(randomHorizontalForce, 0), ForceMode2D.Impulse);  
        }

        ballCount++;
        if (ballCount >= 5)
        {
            ReduceSpawnInterval();
            ballCount = 0; 
        }
    }

    void ReduceSpawnInterval()
    {
        spawnInterval = Mathf.Max(1f, spawnInterval - 1f); 
        CancelInvoke("SpawnRandomBall");
        InvokeRepeating("SpawnRandomBall", spawnInterval, spawnInterval);
    }

    void Update()
    {
        
    }
}
