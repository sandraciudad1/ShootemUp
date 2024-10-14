using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Static Instance
    public static gameManager gameManagerInstance { get; private set; }

    //Static Variables
    public int points = 0;
    public int first = 0;
    public int second = 0;
    public int third = 0;

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("first", first);
        PlayerPrefs.SetInt("second", second);
        PlayerPrefs.SetInt("third", third);
    }

    public void LoadProgress()
    {
        points = PlayerPrefs.GetInt("points", 0);
        first = PlayerPrefs.GetInt("first", first);
        second = PlayerPrefs.GetInt("second", second);
        third = PlayerPrefs.GetInt("third", third);
    }
}
