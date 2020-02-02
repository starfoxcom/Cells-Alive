﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    GameObject myObject;
    public Vector2 direction;
    public float speed=0.05f;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GetComponent<GameObject>();

        // Kills the game object in 5 seconds after loading the object
        Destroy(this.gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu pause = FindObjectOfType<PauseMenu>();
        if (pause.GameIsPaused)
        {
            return;
        }
        this.transform.position = new Vector3(this.transform.position.x+(direction.x*speed),
            this.transform.position.y + (direction.y * speed),
            this.transform.position.z);
        //direction *= 0.0002f;
        RaycastHit2D hit= Physics2D.Raycast(this.transform.position, direction,0.02f);
       if (hit.collider!=null&& hit.collider.gameObject.tag=="Herida")
       {
           hit.collider.gameObject.GetComponent<herida>().porcentaje -= 2f;
           Destroy(this.gameObject);
       }
        if (hit.collider != null && hit.collider.gameObject.tag == "MapWall")
        {
            Destroy(this.gameObject);
        }

    }
   
}
