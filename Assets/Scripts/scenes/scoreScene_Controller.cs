using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreScene_Controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI yourScore;
    [SerializeField] TextMeshProUGUI firstScore;
    [SerializeField] TextMeshProUGUI secondScore;
    [SerializeField] TextMeshProUGUI thirdScore;

    void Start()
    {
        yourScore.text = gameManager.gameManagerInstance.points.ToString();
        updateRanking(gameManager.gameManagerInstance.points);
    }

    void updateRanking(int points)
    {
        int first = gameManager.gameManagerInstance.first;
        int second = gameManager.gameManagerInstance.second;
        int third = gameManager.gameManagerInstance.third;

        if (points > first)
        {
            gameManager.gameManagerInstance.third = gameManager.gameManagerInstance.second;
            gameManager.gameManagerInstance.second = gameManager.gameManagerInstance.first;
            gameManager.gameManagerInstance.first = gameManager.gameManagerInstance.points;
        }
        else if (points > second)
        {
            gameManager.gameManagerInstance.third = gameManager.gameManagerInstance.second;
            gameManager.gameManagerInstance.second = gameManager.gameManagerInstance.points;
        }
        else if (points > third)
        {
            gameManager.gameManagerInstance.third = gameManager.gameManagerInstance.points;
        }

        firstScore.text = gameManager.gameManagerInstance.first.ToString();
        secondScore.text = gameManager.gameManagerInstance.second.ToString();
        thirdScore.text = gameManager.gameManagerInstance.third.ToString();
    }

    public void arrowBtn()
    {
        gameManager.gameManagerInstance.points = 0;
        gameManager.gameManagerInstance.SaveProgress();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("mainScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
