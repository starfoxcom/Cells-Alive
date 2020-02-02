using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual float JeftJoyAxisX()
    {
        return 0;
    }
    public virtual float JeftJoyAxisY()
    {
        return 0;
    }

    public virtual Vector3 JoystickAxis()
    {
        return new Vector3(JeftJoyAxisX(), JeftJoyAxisY(), 0);
    }

    public virtual float DpadAxisX()
    {
        return 0;
    }
    public virtual float DpadAxisY()
    {
        return 0;
    }

    public virtual Vector3 DpadAxisAxis()
    {
        return new Vector3(DpadAxisX(), DpadAxisY(), 0);
    }

    public virtual float LeftTriggerAxis()
    {
        return 0;
    }
    public virtual float RightTriggerAxis()
    {
        return 0;
    }

    public virtual bool JumpButton()
    {
 
        return false;
    }
    public virtual bool AccionButton()
    {

        return false;
    }
    public virtual bool PauseButton()
    {

        return false;
    }
    public virtual bool changeTipeBullet()
    {
        return false;
    }
}
