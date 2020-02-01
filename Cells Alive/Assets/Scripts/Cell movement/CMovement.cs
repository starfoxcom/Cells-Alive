/**
* @LC		: 31/01/2020
* @file		: CMovement.cpp
* @Author	: Jesús Alberto Del Moral Cupil
* @Email	: idv18c.jmoral@uartesdigitales.edu.mx
* @date		: 31/01/2020
* @brief	: A basic description of the what do the doc.
* @bug		: No Bugs known.
**/

/**
* Usings
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/**
* @brief	: Movement Class.
* @bug		: No bugs known.
**/
public class CMovement : Modul
{



    public float velocity = 10f;
    public Vector2 ActMovement;
    public Rigidbody2D RigBod;

    /**
    * @brief	: Keyboar inputs.
    * @bug		: No bugs known.
    **/
    void InputKeyboard() {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
            moveDiagLeftUp();
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
            moveDiagRightUp();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
            moveDiagLeftDown();
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
            moveDiagRightDown();
        }

        else if (Input.GetKey(KeyCode.W)) {
            moveUp();
        }
        else if (Input.GetKey(KeyCode.S)) {
            moveDown();
        }

        else if (Input.GetKey(KeyCode.A)) {
            moveLeft();
        }
        else if (Input.GetKey(KeyCode.D)) {
            moveRight();
        }

        else {
            ActMovement.x = 0;
            ActMovement.y = 0;
        }
    }



    /**
    * @brief	: Inputs 4 controller.
    * @bug		: No bugs known.
    **/
    void InputController() {
        
        if ((input.JeftJoyAxisY() <= 0.3) && (input.JeftJoyAxisX() <= -0.3)) {
            moveDiagLeftUp();
        }
        else if ((input.JeftJoyAxisY() <= 0.3) && (input.JeftJoyAxisX() >= 0.3)) {
            moveDiagRightUp();
        }
        else if ((input.JeftJoyAxisY() >= -0.3) && (input.JeftJoyAxisX() <= -0.3)) {
            moveDiagLeftDown();
        }
        else if ((input.JeftJoyAxisY() >= -0.3) && (input.JeftJoyAxisX() >= 0.3)) {
            moveDiagRightDown();
        }

        else if (input.JeftJoyAxisY() >= 1) {
            moveDown();
        }
        else if (input.JeftJoyAxisY() <= -1) {
            moveUp();
        }

        else if (input.JeftJoyAxisX() <= -1) {
            moveLeft();
        }
        else if (input  .JeftJoyAxisX() >= 1) {
            moveRight();
        }
        else {
            ActMovement.x = 0;
            ActMovement.y = 0;
        }
    }



    /**
    * @brief	: Update of the class.
    * @bug		: No bugs known.
    **/
    void Update() {
        if (!isActive)
        {
            return;
        }
        //InputKeyboard();
        InputController();
        move(RigBod);
        ActMovement.x = 0;
        ActMovement.y = 0;

    }



    /**
    * @brief	: Movement in +x.
    * @bug		: No bugs known.
    **/
    public void moveRight() {
        ActMovement.x = velocity;
    }

    /**
    * @brief	: Movement in -x.
    * @bug		: No bugs known.
    **/
    public void moveLeft() {
        ActMovement.x = -velocity;
    }


    /**
    * @brief	: Movement in +y.
    * @bug		: No bugs known.
    **/
    public void moveUp() {
        ActMovement.y = velocity;
    }

    /**
    * @brief	: Movement in -y.
    * @bug		: No bugs known.
    **/
    public void moveDown() {
        ActMovement.y = -velocity;
        
    }


    /**
    * @brief	: Function 4 move to Left Up.
    * @bug		: No bugs known.
    **/
    public void moveDiagLeftUp() {
        ActMovement.x = -velocity;
        ActMovement.y = velocity;
    }

    /**
    * @brief	: Function 4 move to Left Down.
    * @bug		: No bugs known.
    **/
    public void moveDiagLeftDown()
    {
        ActMovement.x = -velocity;
        ActMovement.y = -velocity;
    }



    /**
    * @brief	: Function 4 move to Right Up.
    * @bug		: No bugs known.
    **/
    public void moveDiagRightUp()
    {
        ActMovement.x = velocity;
        ActMovement.y = velocity;
    }



    /**
    * @brief	: Function 4 move to Right Down.
    * @bug		: No bugs known.
    **/
    public void moveDiagRightDown()
    {
        ActMovement.x = velocity;
        ActMovement.y = -velocity;
    }



    /**
    * @brief	: Function 4 move to Right Down.
    * @param	: RighidBody 2D 4 make the movement.
    * @bug		: No bugs known.
    **/
    public void move(Rigidbody2D m_Body) {
        m_Body.velocity = ActMovement; //moverse en X
    }


}
