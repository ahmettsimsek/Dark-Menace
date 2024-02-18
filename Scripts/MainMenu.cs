using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Intro");
    }

    public void OnOptionButton()
    {
        SceneManager.LoadScene("Options");
    }


    public void OnQuitButton()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
        

    }
}
