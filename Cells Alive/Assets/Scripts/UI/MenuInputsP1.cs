using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputsP1 : MonoBehaviour
{
    public InputManager inputs;
    //public MainMenu mainmenu;
    public MENUin menuimpu;
    int Index = 0;
    bool isMove = false;
    float axis = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputs = FindObjectOfType<inputManagerP1>();

        Index = menuimpu.Index;
        float y = inputs.JeftJoyAxisY();
        //y *= -1;
        if (y > -0.3 && y < 0.3)
        {
            y = 0;

        }
        else
        {
            if (y < -0.3)
            {
                y = -1;
            }
            else
            {
                y = 1;
            }
        }
        if (y == 0)
        {
            isMove = false;
        }

        if (y != 0 && !isMove)
        {
            isMove = true;
            if (y > 0)
            {
                Index++;
            }
            else if (y < 0)
            {
                Index--;
            }
        }
        menuimpu.Index = Index;
        if (inputs.JumpButton())
        {
            menuimpu.selected();
        }
    }
}
