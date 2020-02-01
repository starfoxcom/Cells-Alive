using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool IfyouPassHere = false;
    public void PlayGame()
    {
        if (IfyouPassHere == false)
        {
            IfyouPassHere = true;
            SceneManager.LoadScene("Pausa");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
} 
  