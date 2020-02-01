using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoInter : MonoBehaviour
{
    public bool m_OnFloor, m_OnStair, m_OnModule, m_PressF;
    public Modul currentModul;
    public bool isActive = true;
    public bool isGrounded = false;
    public bool fall = true;
    public float fallTime = 0;
    public float SeparateTime = 0;
    public float cgravity = 0.2f;
    public bool separate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void gravedad()
    {
        RaycastHit2D Hit;
        if (isGrounded)
        {
            Hit = Physics2D.Raycast(this.transform.position, new Vector2(0, -1), 0.2f);
            if (Hit.collider == null)
                fall = true;
        }

        if (!fall)
        {
            fallTime = 0;
            return;
        }
        fallTime += Time.deltaTime;
        float vy =  ((cgravity) * fallTime);
        if (vy <= 0)
        {
            fall = true;
        }
        else
        {
            fall = false;
        }
        // Debug.Log(vyNegative);
        Hit = Physics2D.Raycast(this.transform.position, new Vector2(0, 1), vy);
        if (Hit.collider != null && Hit.collider.tag == "Floor" && fall)
        {
            if (this.separate)
            {
                return;
            }
            //fall = false;
            //separate = false;
            //myObject.isGrounded = true;
            //myObject.currentJump = 0;
            //myObject.transform.position = new Vector3(myObject.transform.position.x, 
            //   collision.gameObject.GetComponent<pivot>().pTranform.position.y,
            //    myObject.transform.position.z);
            fallTime = 0;
            vy = Hit.collider.gameObject.GetComponent<pivot>().pTranform.position.y;
            this.transform.position = new Vector3(this.transform.position.x,
               Hit.collider.gameObject.GetComponent<pivot>().pTranform.position.y,
                this.transform.position.z);
            Debug.Log("Raytcast");
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + vy, this.transform.position.z);
        }
    }
}
