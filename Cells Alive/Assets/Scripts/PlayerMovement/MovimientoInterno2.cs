using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoInterno2 : MovimientoInter
{
    public inputManagerP2 P1;
    public float m_Speed, m_JumpBust, m_Gravity;
    float m_VelocityY, m_VelocityX;

    // Update is called once per frame
    void Update()
    {
        //PauseMenu pause = FindObjectOfType<PauseMenu>();
        //if (pause.GameIsPaused)
        //{
        //    return;
        //}
        if (m_OnModule)
        {
            currentModul.onUpdate();
            return;
        }
        //if (P1.JumpButton())
        //{
        //    m_JumpBust = 0.2f;
        //    separate = true;
        //}
        if (separate)
        {
            SeparateTime += Time.deltaTime;
            if (SeparateTime > 0.2f)
            {
                SeparateTime = 0;
                separate = false;
            }
        }
        Vector3 dir = P1.JoystickAxis();
        if (m_OnStair)
        {
            dir.y *= -1;
        }
        else
        {
            gravedad();
            dir.y = 0;

        }
        dir.z = 0;
        dir.Normalize();
        this.transform.position += dir * m_Speed;
        paredes();
        //if (!m_OnModule)//Player not on a module
        //{
        //    if (m_OnStair)//Player on a stair
        //    {
        //        /*if (Input.GetKey(KeyCode.W))//User press W
        //        {
        //            transform.Translate(0, m_Speed * Time.deltaTime, 0);
        //        }
        //        if (Input.GetKey(KeyCode.S))//User press S
        //        {
        //            transform.Translate(0, -m_Speed * Time.deltaTime, 0);
        //        }*/
        //        if (P1.JeftJoyAxisY() <= -1)
        //        {
        //            transform.Translate(0, m_Speed * Time.deltaTime, 0);
        //        }
        //        else if (P1.JeftJoyAxisY() >= 1 && !m_OnFloor)
        //        {
        //            transform.Translate(0, -m_Speed * Time.deltaTime, 0);
        //        }
        //    }
        //    /*if (Input.GetKey(KeyCode.A))//User press A
        //    {
        //        transform.Translate(-m_Speed * Time.deltaTime, 0, 0);
        //    }
        //    if (Input.GetKey(KeyCode.D))//User press D
        //    {
        //        transform.Translate(m_Speed * Time.deltaTime, 0, 0);
        //    }*/
        //    if (P1.JeftJoyAxisX() <= -1)//User press A
        //    {
        //        transform.Translate(-m_Speed * Time.deltaTime, 0, 0);
        //    }
        //    if (P1.JeftJoyAxisX() >= 1)//User press D
        //    {
        //        transform.Translate(m_Speed * Time.deltaTime, 0, 0);
        //    }
        //    if (m_OnFloor || m_OnStair)//Player on floor or on a stair
        //    {
        //        m_VelocityY = 0;
        //        /*if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            m_VelocityY += m_JumpBust;
        //            m_OnStair = false;
        //        }*/
        //        if (P1.JumpButton())
        //        {
        //            m_VelocityY += m_JumpBust;
        //            m_OnStair = false;
        //        }
        //    }
        //    else//Player not on floor
        //    {
        //        //if (m_VelocityY >= 0)//Positive velocity on Y axis of player 
        //        //{
        //        //    m_VelocityY -= m_Gravity * Time.deltaTime;
        //        //}
        //        //else//Negative velocity on Y axis of player 
        //        //{
        //        //    m_VelocityY -= m_Gravity * Time.deltaTime * 2;
        //        //}
        //        gravedad();
        //    }
        //        gravedad();
        //    //transform.Translate(0, m_VelocityY * Time.deltaTime, 0);
        //   //RaycastHit m_Colider;
        //   //Vector3 physicsCentre = transform.position + GetComponent<SphereCollider>().center;//Adjust the raycast on the center of the player
        //   //if (Physics.Raycast(transform.position, Vector3.down, out m_Colider, 0.2f))//If raycast collides with an object
        //   //{
        //   //    if (m_Colider.transform.gameObject.tag == "Floor")//If the tag of the object is "Floor" so the player is on the floor
        //   //    {
        //   //        m_OnFloor = true;
        //   //    }
        //   //}
        //   //else
        //   //{
        //   //    m_OnFloor = false;
        //   //}
        //}
        //else//Player on a module
        //{
        //    currentModul.onUpdate();
        //}
        //if (m_PressF && P1.AccionButton())
        //{
        //    m_PressF = false;
        //}
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Stair" && P1.JeftJoyAxisY() != 0)
        {
            m_OnStair = true;
        }

        //if (other.tag == "Stair" && P1.JeftJoyAxisY() != 0)
        //{
        //    m_OnStair = true;
        //}
        ////if (other.tag == "Module" && P1.AccionButton())
        ////{
        ////    if (!m_PressF)
        ////    {
        ////        m_OnModule = !m_OnModule;
        ////        transform.position = other.transform.position;
        ////        m_VelocityY = 0;
        ////        m_PressF = true;
        ////    }
        ////}
        if (other.tag == "Module" && P1.AccionButton())
        {
            if (other.GetComponent<Modul>().isActive)
            {
                return;
            }
            currentModul = other.GetComponent<Modul>();

            currentModul.input = P1;
            currentModul.myManager = this;
            m_OnModule = true;
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stair")
        {
            m_OnStair = false;
        }
    }
    public override void gravedad()
    {
        RaycastHit2D Hit;
        if (isGrounded)
        {
            Hit = Physics2D.Raycast(this.gameObject.transform.position, new Vector2(0, -1), 2.2f);
            if (Hit.collider == null)
                fall = true;
            else if (Hit.collider.gameObject.tag == "Floor")
            {
                m_JumpBust = 0;
                fall = false;
            }
        }

        if (!fall)
        {
            fallTime = 0;
            return;
        }
        fallTime += Time.deltaTime;
        float vy = m_JumpBust - ((cgravity) * fallTime);
        if (vy <= 0)
        {
            fall = true;
        }
        else
        {
            fall = false;
        }
        // Debug.Log(vyNegative);
        Hit = Physics2D.Raycast(this.gameObject.transform.position, new Vector2(0, 1), vy - 2.2f);
        if (Hit.collider != null && Hit.collider.tag == "Floor" && fall)
        {
            if (this.separate)
            {
                return;
            }

            fallTime = 0;
            vy = Hit.collider.gameObject.GetComponent<pivot>().pTranform.position.y;
            this.transform.position = new Vector3(this.gameObject.transform.position.x,
               Hit.collider.gameObject.GetComponent<pivot>().pTranform.position.y,
                this.transform.position.z);
            Debug.Log("Raytcast");
        }
        else
        {
            this.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + vy, this.gameObject.transform.position.z);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Floor")
        //{
        //    fallTime = 0;
        //    this.isGrounded = true;
        //    fall = true;
        //}
    }
    public void paredes()
    {
        RaycastHit2D Hit;
        Hit = Physics2D.Raycast(this.gameObject.transform.position, new Vector2(1, 0), 0.02f);
        if (Hit.collider != null && Hit.collider.tag == "Wall")
        {
            this.transform.position = new Vector3(Hit.collider.gameObject.GetComponent<pivot>().pTranform.position.x,
                this.gameObject.transform.position.y,
                this.transform.position.z);
        }
        Hit = Physics2D.Raycast(this.gameObject.transform.position, new Vector2(-1, 0), 0.02f);
        if (Hit.collider != null && Hit.collider.tag == "Wall")
        {
            this.transform.position = new Vector3(Hit.collider.gameObject.GetComponent<pivot>().pTranform.position.x,
                this.gameObject.transform.position.y,
                this.transform.position.z);
        }
    }
}
