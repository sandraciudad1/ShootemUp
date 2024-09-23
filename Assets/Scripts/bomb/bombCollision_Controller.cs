using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombCollision_Controller : MonoBehaviour
{
    int points;
    [SerializeField] private GameObject pinkBall;
    [SerializeField] private GameObject redBall;
    [SerializeField] private GameObject yellowBall;
    [SerializeField] private GameObject greenBall;
    [SerializeField] private GameObject blueBall;
    int numberPinkBalls, numberRedBalls, numberYellowBalls, numberGreenBalls, numberBlueBalls;
    GameObject[] pinkBalls, redBalls, yellowBalls, greenBalls, blueBalls;
    void Start()
    {
        points = PlayerPrefs.GetInt("points", 0);
    }
        
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
            foreach (GameObject pink in pinkBalls)
            {
                Destroy(pink);
            }
            foreach (GameObject red in redBalls)
            {
                Destroy(red);
            }
            foreach (GameObject yellow in yellowBalls)
            {
                Destroy(yellow);
            }
            foreach (GameObject green in greenBalls)
            {
                Destroy(green);
            }
            foreach (GameObject blue in blueBalls)
            {
                Destroy(blue);
            }
            
            int pinkPoints = numberPinkBalls * 10;
            int redPoints = numberRedBalls * 25;
            int yellowPoints = numberYellowBalls * 45;
            int greenPoints = numberGreenBalls * 70;
            int bluePoints = numberBlueBalls * 100;

            points = points + pinkPoints + redPoints + yellowPoints + greenPoints + bluePoints;
            PlayerPrefs.SetInt("points", points);
            Destroy(gameObject);
            ballGenerator_Controller ballGen = GameObject.Find("gameplayCamera").GetComponent<ballGenerator_Controller>();
            if (ballGen != null)
            {
                ballGen.SpawnRandomBall();
            }
        }
    }


}
