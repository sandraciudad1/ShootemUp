using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombCollision_Controller : MonoBehaviour
{
    [SerializeField] private GameObject pinkBall;
    [SerializeField] private GameObject redBall;
    [SerializeField] private GameObject yellowBall;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private GameObject blueBall;
    int numberPinkBalls, numberRedBalls, numberYellowBalls, numberGreenBalls, numberBlueBalls;
    GameObject[] pinkBalls, redBalls, yellowBalls, greenBalls, blueBalls;
        
    void Update()
    {
        numberPinkBalls = GameObject.FindGameObjectsWithTag("pinkBall").Length;
        numberRedBalls = GameObject.FindGameObjectsWithTag("redBall").Length;
        numberYellowBalls = GameObject.FindGameObjectsWithTag("yellowBall").Length;
        numberGreenBalls = GameObject.FindGameObjectsWithTag("greenBall").Length;
        numberBlueBalls = GameObject.FindGameObjectsWithTag("blueBall").Length;

        pinkBalls = GameObject.FindGameObjectsWithTag("pinkBall");
        redBalls = GameObject.FindGameObjectsWithTag("redBall");
        yellowBalls = GameObject.FindGameObjectsWithTag("yellowBall");
        greenBalls = GameObject.FindGameObjectsWithTag("greenBall");
        blueBalls = GameObject.FindGameObjectsWithTag("blueBall");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cannon"))
        {
            bombManager.bombManagerInstance.bombUsed();

            managePoints();

            Destroy(gameObject);
            ballGenerator_Controller ballGen = GameObject.Find("gameplayCamera").GetComponent<ballGenerator_Controller>();
            if (ballGen != null)
            {
                ballGen.SpawnRandomBall();
            }
        }
    }

    void managePoints()
    {
        gameManager.gameManagerInstance.points = gameManager.gameManagerInstance.points + (numberPinkBalls*10) + (numberRedBalls*25) + (numberYellowBalls*45) + (numberGreenBalls*70) + (numberBlueBalls*100);
        gameManager.gameManagerInstance.SaveProgress();
    }
}
