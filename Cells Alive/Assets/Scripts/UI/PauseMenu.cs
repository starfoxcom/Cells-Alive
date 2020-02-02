using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject MenuPause;
    public InputManager []inputs;

    void Start()
    {
        GameIsPaused = false;
    }
    void Update()
    {
        //inputs = FindObjectsOfType<InputManager>();
        //for (int i = 0; i < inputs.Length; i++)
        //{
        //    if (inputs[i].PauseButton())
        //    {
        //        if (GameIsPaused)
        //        {
        //            Resume();
        //        }
        //        else
        //        {
        //            Pause();
        //        }
        //
        //    }
        //
        //}
        //if(Input.GetKey(KeyCode.Escape))
        //{
        //    if(GameIsPaused)
        //    {
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //
        //}
        
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
        Destroy(this.gameObject);
        SceneManager.LoadScene("Menu");
    }

    public void Onupdate()
    {
        inputs = FindObjectsOfType<InputManager>();
        for (int i = 0; i < inputs.Length; i++)
        {
            if (inputs[i].PauseButton())
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }

            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
}
