using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject MenuPause;

    void Start()
    {
        GameIsPaused = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
        
    }

    public void Resume ()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturnMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }
}
