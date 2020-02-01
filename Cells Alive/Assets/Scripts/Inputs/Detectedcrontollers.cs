using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectedcrontollers : MonoBehaviour
{
    public inputManagerP1 inputsPlayer1;
    public inputManagerP2 inputsPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 19)
            {
                print("controller " + x + " PS4 CONTROLLER IS CONNECTED");
                
                if (x == 0)
                {
                    inputsPlayer1.isPs4 = true;
                }
                else
                {
                    inputsPlayer2.isPs4 = true;
                }
            }
            if (names[x].Length == 33)
            {
                print("controller " + x + " XBOX ONE CONTROLLER IS CONNECTED");
                
                if (x == 0)
                {
                    inputsPlayer1.isXbox = true;
                }
                else
                {
                    inputsPlayer2.isXbox = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
