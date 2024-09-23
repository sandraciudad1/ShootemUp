using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreScene_Controller : MonoBehaviour
{
    int points;
    [SerializeField] TextMeshProUGUI yourScore;
    [SerializeField] TextMeshProUGUI firstScore;
    [SerializeField] TextMeshProUGUI secondScore;
    [SerializeField] TextMeshProUGUI thirdScore;

    void Start()
    {
        points = PlayerPrefs.GetInt("points", 0);
        yourScore.text = points.ToString();
        updateRanking(points);
    }

    void Update()
    {
        
    }

    void updateRanking(int points)
    {
        int first = PlayerPrefs.GetInt("first", 0);
        int second = PlayerPrefs.GetInt("second", 0);
        int third = PlayerPrefs.GetInt("third", 0);

        if (points > first)
        {
            PlayerPrefs.SetInt("third", second);
            PlayerPrefs.SetInt("second", first);
            PlayerPrefs.SetInt("first", points);
        }
        else if (points > second)
        {
            PlayerPrefs.SetInt("third", second);
            PlayerPrefs.SetInt("second", points);
        }
        else if (points > third)
        {
            PlayerPrefs.SetInt("third", points);
        }

        firstScore.text = PlayerPrefs.GetInt("first").ToString();
        secondScore.text = PlayerPrefs.GetInt("second").ToString();
        thirdScore.text = PlayerPrefs.GetInt("third").ToString();
    }

    public void arrowBtn()
    {
        PlayerPrefs.SetInt("points", 0);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("mainScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
