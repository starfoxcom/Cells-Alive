using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseInput : MENUin
{
    // Start is called before the first frame update
    public Image Resumen;
    public Image MainMenu;
    public PauseMenu pause;
    void Start()
    {

        Resumen.enabled = false;
        MainMenu.enabled = false;
        return;
    }

    // Update is called once per frame
    void Update()
    {
        pause.Onupdate();
        if (!pause.GameIsPaused)
        {
            Resumen.enabled = false;
            MainMenu.enabled = false;
            return;
        }
        if (Index > 1)
        {
            Index = 0;
        }
        if (Index < 0)
        {
            Index = 1;
        }

        if (Index == 0)
        {
            Resumen.enabled = true;
            MainMenu.enabled = false;
        }
        else if (Index == 1)
        {
            Resumen.enabled = false;
            MainMenu.enabled = true;
        }
    }
    public override void selected()
    {

        if (Index == 0)
        {
            pause.Resume();
        }
        else if (Index == 1)
        {
            pause.ReturnMenu();
        }
    }
}
