using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Modul
{
    public Medicine medicinePrefab;
    public GlobuloRojo AtackPrefab;
    public Transform globuloTransform;
    public Vector3 actualDir;
    public float ratio;
    public bool isUpRight=false;
    public bool isDownRight= false;
    public bool isUpLeft= false;
    public bool isDownLeft= false;
    public float speed = 0.01f;
    public bool healingAmmunition;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 dir;
        dir = new Vector3(0, 0, 0);
        if (isUpRight)
        {
            dir = new Vector3(1,1,0);
        }
        if (isDownRight)
        {
            dir = new Vector3(1, -1, 0);
        }
        if (isUpLeft)
        {
            dir = new Vector3(-1, 1, 0);
        }
        if (isDownLeft)
        {
            dir = new Vector3(-1, -1, 0);
        }
        dir.z = 0;
        dir.Normalize();
        this.transform.position = new Vector3(globuloTransform.position.x + dir.x * ratio,
           globuloTransform.position.y + dir.y * ratio,
           globuloTransform.position.z);
        actualDir = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }
        if (input.changeTipeBullet())
        {
            if (healingAmmunition)
            {
                healingAmmunition = false;
            }
            else
            {
                healingAmmunition = true;
            }
        }
        // Vector3 mousePos= Input.mousePosition;
        // mousePos= Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 dir = actualDir;
        if (input.JeftJoyAxisX()>=1|| input.DpadAxisX()>=1)
        {
            if(isUpRight||isDownLeft)
            {
                dir.x += speed;
                dir.y -= speed;
            }
            else
            {
                dir.x += speed;
                dir.y += speed;
            }
            
        }
        else if (input.JeftJoyAxisX() <= -1 || input.DpadAxisX() <= -1)
        {
            if (isUpRight || isDownLeft)
            {
                dir.x -= speed;
                dir.y += speed;
            }
            else
            {
                dir.x -= speed;
                dir.y -= speed;
            }
        }
        dir.z = 0;
        dir.Normalize();
        if (isUpRight)
        {
            if (dir.x < 0)
            {
                dir.x = 0;
                dir.y = 1;
            }
            else if (dir.y < 0)
            {
                dir.x = 1;
                dir.y = 0;
            }
        }
        if (isDownRight)
        {
            if (dir.x < 0)
            {
                dir.x = 0;
                dir.y = -1;
            }
            else if (dir.y > 0)
            {
                dir.x = 1;
                dir.y = 0;
            }
        }
        if (isUpLeft)
        {
            if (dir.x > 0)
            {
                dir.x = 0;
                dir.y = 1;
            }
            if (dir.y < 0)
            {
                dir.x = -1;
                dir.y = 0;
            }
        }
        if (isDownLeft)
        {
            if (dir.x > 0)
            {
                dir.x = 0;
                dir.y = -1;
            }
            if (dir.y > 0)
            {
                dir.x = -1;
                dir.y = 0;
            }
        }
        actualDir = dir;
        this.transform.position = new Vector3(globuloTransform.position.x+dir.x*ratio,
            globuloTransform.position.y + dir.y * ratio,
            globuloTransform.position.z);
        //if (Input.GetMouseButtonDown(0))
        if (input.RightTriggerAxis()>=1)
        {
            if (healingAmmunition)
            {
                Medicine newMedicine = Instantiate(medicinePrefab, this.transform.position, Quaternion.identity);
                //Vector3 dir = mousePos-GetComponent<Transform>().position;
                Debug.Log(dir);
                // dir.z = 0;
                // dir.Normalize();
                newMedicine.direction = new Vector2(dir.x, dir.y);
            }
            else
            {
                GlobuloRojo newMedicine = Instantiate(AtackPrefab, this.transform.position, Quaternion.identity);
                //Vector3 dir = mousePos-GetComponent<Transform>().position;
                Debug.Log(dir);
                // dir.z = 0;
                // dir.Normalize();
                newMedicine.direction = new Vector2(dir.x, dir.y);
            }
            
        }
        
    }
}
