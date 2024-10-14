using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cannonCollision_Controller : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pinkBall") || other.CompareTag("redBall") || other.CompareTag("yellowBall") || other.CompareTag("greenBall") || other.CompareTag("blueBall"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("scoreScene");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
