using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManagerP2 : MonoBehaviour
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
            axis = Input.GetAxis("Ps4_Horizontal(Joystick)_2");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Horizontal(Joystick)_2");
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
            axis = Input.GetAxis("Ps4_Vertical(Joystick)_2");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Vertical(Joystick)_2");
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
            axis = Input.GetAxis("Ps4_Dpad_X_2");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Dpad_X_2");
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
            axis = Input.GetAxis("Ps4_Dpad_Y_2");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_Dpad_Y_2");
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
            axis = Input.GetAxis("Ps4_L2_2");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_LT_2");
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
            axis = Input.GetAxis("Ps4_R2_2");
        }
        else if (isXbox)
        {
            axis = Input.GetAxis("Xbox_RT_2");
        }
        else
            axis = 0;
        return Mathf.Clamp(axis, -1.0f, 1.0f);
    }

    public  bool JumpButton()
    {
        if (isPs4)
        {
            return Input.GetButtonDown("Ps4_X_2");
        }
        else if (isXbox)
        {
            return Input.GetButtonDown("Xbox_A_2");
        }
        return false;
    }
    public  bool AccionButton()
    {
        if (isPs4)
        {
            return Input.GetButtonDown("Ps4_Circle_2");
        }
        else if (isXbox)
        {
            return Input.GetButtonDown("Xbox_B_2");
        }
        return false;
    }
    // public static bool jostickMoveHorizontal()
    // {
    //     if (EjeHorizontal() != 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // public static bool jostickMoveVertical()
    // {
    //     if (EjeVertical() != 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    //
    // public static bool UPButton()
    // {
    //     float i = Input.GetAxis("UP");
    //     if (i > 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // public static bool DOWNButton()
    // {
    //     float i = Input.GetAxis("UP");
    //     if (i < 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // public static bool RightButton()
    // {
    //     float i = Input.GetAxis("RIGHT");
    //     if (i > 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    // public static bool LefhtButton()
    // {
    //     float i = Input.GetAxis("RIGHT");
    //     if (i < 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    //
    // //Botones
    // public static bool AButton()
    // {
    //     return Input.GetButtonDown("Boton_A");
    // }
    // public static bool BButton()
    // {
    //     return Input.GetButtonDown("Boton_B");
    // }
    // public static bool XButton()
    // {
    //     return Input.GetButtonDown("Boton_X");
    // }
    // public static bool YButton()
    // {
    //     return Input.GetButtonDown("Boton_Y");
    // }
    // public static bool StartButton()
    // {
    //     return Input.GetButtonDown("Start");
    // }
    // public static bool BackButton()
    // {
    //     return Input.GetButtonDown("Back");
    // }
    // public static bool RBButton()
    // {
    //     return Input.GetButtonDown("RB");
    // }
    // public static bool LBButton()
    // {
    //     return Input.GetButtonDown("LB");
    // }
    // public static bool anyButton()
    // {
    //     if (LBButton())
    //         return true;
    //     if (RBButton())
    //         return true;
    //     if (BackButton())
    //         return true;
    //     if (StartButton())
    //         return true;
    //     if (YButton())
    //         return true;
    //     if (XButton())
    //         return true;
    //     if (BButton())
    //         return true;
    //     if (AButton())
    //         return true;
    //     return false;
    // }
}
