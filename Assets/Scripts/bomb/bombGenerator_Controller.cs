using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombGenerator_Controller : MonoBehaviour
{
    int points;
    [SerializeField] GameObject bomb;
    GameObject newBomb;
    float countdownTime = 5f;
    bool startCounter = false;
    int lastBombSpawnPoints = 0;  

    void Update()
    {
        points = PlayerPrefs.GetInt("points", 0);

        if (points % 500 == 0 && points != lastBombSpawnPoints && points > 0)
        {
            Vector2 position = new Vector2(Random.Range(-7.7f, 8f), Random.Range(-3f, -2f));
            newBomb = Instantiate(bomb, position, Quaternion.identity);

            startCounter = true;
            lastBombSpawnPoints = points; 
            countdownTime = 5f;  
        }

        if (startCounter)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime;
                countdownTime = Mathf.Clamp(countdownTime, 0f, 5f);
            }
            else
            {
                Destroy(newBomb);
                startCounter = false; 
            }
        }
    }
}
