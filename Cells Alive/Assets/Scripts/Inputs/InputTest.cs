using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public inputManagerP1 inputsPlayer1;
    public inputManagerP2 inputsPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<inputManagerP1>().JumpButton())
        {
            print("JUMP BUTTON CONTROL 1");
        }
        if (FindObjectOfType<inputManagerP1>().AccionButton())
        {
            print("ACTION BUTTON CONTROL 1");
        }

       if (FindObjectOfType<inputManagerP2>().JumpButton())
       {
           print("JUMP BUTTON CONTROL 2");
       }
       if (FindObjectOfType<inputManagerP2>().AccionButton())
       {
           print("ACTION BUTTON CONTROL 2");
       }
    }
}
