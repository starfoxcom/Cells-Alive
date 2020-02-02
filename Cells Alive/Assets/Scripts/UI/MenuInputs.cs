using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInputs : MENUin
{
    // Start is called before the first frame update
    public Image newGame;
    public Image credits;
    public Image exit;
    
    public MainMenu mainmenu;
   
    bool isMove=false;
    float axis=0;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Index>2)
        {
            Index = 0;
        }
        if (Index < 0)
        {
            Index = 2;
        }

        if (Index == 0)
        {
            newGame.enabled = true;
            credits.enabled = false;
            exit.enabled = false;
        }
        else if(Index == 1)
        {
            newGame.enabled = false;
            credits.enabled = true;
            exit.enabled = false;
        }
        else if (Index == 2)
        {
            newGame.enabled = false;
            credits.enabled = false;
            exit.enabled = true;
        }
        
    }
    public override void selected()
    {
        inputs = FindObjectsOfType<InputManager>();
        for (int i = 0; i < inputs.Length; i++)
        {
            Destroy(inputs[i]);
        }
        if (Index == 0)
        {
            mainmenu.PlayGame();
        }
        else if (Index == 1)
        {
            mainmenu.PlayCredits();
        }
        else if (Index == 2)
        {
            mainmenu.QuitGame();
        }
    }
}
