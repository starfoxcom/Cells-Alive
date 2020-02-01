﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManagerP1 : MonoBehaviour
{
     public bool isPs4 = false;
     public bool isXbox = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  float JeftJoyAxisX()
    {
        float axis = 0;
        if (isPs4)
        {
            axis = Input.GetAxis("Ps4_Horizontal(Joystick)_1");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Horizontal(Joystick)_1");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }
    public  float JeftJoyAxisY()
    {
        float axis = 0;
        if (isPs4)
        {
            axis = Input.GetAxis("Ps4_Vertical(Joystick)_1");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Vertical(Joystick)_1");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }

    public  Vector3 JoystickAxis()
    {
        return new Vector3(JeftJoyAxisX(), JeftJoyAxisY(), 0);
    }

    public  float DpadAxisX()
    {
        float axis = 0;
        if (isPs4)
        {
            axis = Input.GetAxis("Ps4_Dpad_X_1");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Dpad_X_1");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }
    public  float DpadAxisY()
    {
        float axis = 0;
        if (isPs4)
        {
            axis = Input.GetAxis("Ps4_Dpad_Y_1");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Dpad_Y_1");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }

    public  Vector3 DpadAxisAxis()
    {
        return new Vector3(DpadAxisX(), DpadAxisY(), 0);
    }

    public  float LeftTriggerAxis()
    {
        float axis = 0;
        if (isPs4)
        {
            axis = Input.GetAxis("Ps4_L2_1");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_LT_1");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }
    public  float RightTriggerAxis()
    {
        float axis = 0;
        if (isPs4)
        {
            axis = Input.GetAxis("Ps4_R2_1");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_RT_1");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }

    public  bool JumpButton()
    {
        if (isPs4)
        {
            return Input.GetButtonDown("Ps4_X_1");
        }
        else if (isXbox)
        {
            return Input.GetButtonDown("Xbox_A_1");
        }
        return false;
    }
    public  bool AccionButton()
    {
        if (isPs4)
        {
            return Input.GetButtonDown("Ps4_Circle_1");
        }
        else if (isXbox)
        {
            return Input.GetButtonDown("Xbox_B_1");
        }
        return false;
    }
}
