using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScene_Controller : MonoBehaviour
{
    [SerializeField] GameObject infoScreen;
    [SerializeField] GameObject crossIcon;
    
    void Start()
    {
        /*PlayerPrefs.SetInt("first", 0);
        PlayerPrefs.SetInt("second", 0);
        PlayerPrefs.SetInt("third", 0);
        PlayerPrefs.SetInt("points", 0);
        */
    }

    void Update()
    {
        
    }

    public void infoBtn_Pressed()
    {
        infoScreen.SetActive(true);
        crossIcon.SetActive(true);
    }

    public void crossIcon_Pressed()
    {
        infoScreen.SetActive(false);
        crossIcon.SetActive(false);
    }

    public void startBtn_Pressed()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("gameplayScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
