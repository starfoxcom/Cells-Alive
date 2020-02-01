using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Poner este script en el jugador

public class MovimientoInterno : MonoBehaviour
{
    public inputManagerP1 P1;
    public inputManagerP2 P2;
    public float m_Speed, m_JumpBust, m_Gravity;
    float m_VelocityY, m_VelocityX;
    bool m_OnFloor, m_OnStair, m_OnModule, m_PressF;
    // Update is called once per frame
    void Update()
    {
        if (!m_OnModule)//Player not on a module
        {
            if (m_OnStair)//Player on a stair
            {
                /*if (Input.GetKey(KeyCode.W))//User press W
                {
                    transform.Translate(0, m_Speed * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.S))//User press S
                {
                    transform.Translate(0, -m_Speed * Time.deltaTime, 0);
                }*/
                if (P1.JeftJoyAxisY() >= 1)
                {
                    transform.Translate(0, m_Speed * Time.deltaTime, 0);
                }
                else if (P1.JeftJoyAxisY() <= -1)
                {
                    transform.Translate(0, -m_Speed * Time.deltaTime, 0);
                }
            }
            /*if (Input.GetKey(KeyCode.A))//User press A
            {
                transform.Translate(-m_Speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))//User press D
            {
                transform.Translate(m_Speed * Time.deltaTime, 0, 0);
            }*/
            if (P1.JeftJoyAxisX() <= -1)//User press A
            {
                transform.Translate(-m_Speed * Time.deltaTime, 0, 0);
            }
            if (P1.JeftJoyAxisX() >= 1)//User press D
            {
                transform.Translate(m_Speed * Time.deltaTime, 0, 0);
            }
            if (m_OnFloor || m_OnStair)//Player on floor or on a stair
            {
                m_VelocityY = 0;
                /*if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_VelocityY += m_JumpBust;
                    m_OnStair = false;
                }*/
                if (P1.JumpButton())
                {
                    m_VelocityY += m_JumpBust;
                    m_OnStair = false;
                }
            }
            else//Player not on floor
            {
                if (m_VelocityY >= 0)//Positive velocity on Y axis of player 
                {
                    m_VelocityY -= m_Gravity * Time.deltaTime;
                }
                else//Negative velocity on Y axis of player 
                {
                    m_VelocityY -= m_Gravity * Time.deltaTime * 2;
                }
            }
            transform.Translate(0, m_VelocityY * Time.deltaTime, 0);
            RaycastHit m_Colider;
            Vector3 physicsCentre = transform.position + GetComponent<SphereCollider>().center;//Adjust the raycast on the center of the player
            if (Physics.Raycast(physicsCentre, Vector3.down, out m_Colider, 1.1f))//If raycast collides with an object
            {
                if (m_Colider.transform.gameObject.tag == "Floor")//If the tag of the object is "Floor" so the player is on the floor
                {
                    m_OnFloor = true;
                }
            }
            else
            {
                m_OnFloor = false;
            }
        }
        else//Player on a module
        {
        }
        if (m_PressF && P1.AccionButton())
        {
            m_PressF = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stair" && P1.JeftJoyAxisY() != 0)
        {
            m_OnStair = true;
        }
        if (other.tag == "Module" && P1.AccionButton())
        {
            if (!m_PressF)
            {
                m_OnModule = !m_OnModule;
                transform.position = other.transform.position;
                m_PressF = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stair")
        {
            m_OnStair = false;
        }
    }
}
