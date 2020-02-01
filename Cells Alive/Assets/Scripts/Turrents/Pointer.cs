using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float ratio = 0.3f;
    public Turret myTurret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!myTurret.isActive)
        {
            GetComponent<SpriteRenderer>().enabled=false;
            return;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }

        
        float moduleA = myTurret.actualDir.magnitude;
        float moduleB;
        float angle;
        if (myTurret.isDownLeft || myTurret.isDownRight)
        {
            moduleB = new Vector3(-1, 0, 0).magnitude;
            angle = Mathf.Acos(-myTurret.actualDir.x / (moduleA * moduleB));
        }
        else
        {
            moduleB = new Vector3(1, 0, 0).magnitude;
            angle = Mathf.Acos(myTurret.actualDir.x / (moduleA * moduleB));
        }
        angle *= 57.2958f;
        // transform.rotation = ;
        // this.gameObject.transform.Rotate(0, 0, angle);
        if (myTurret.isDownLeft||myTurret.isDownRight)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle+270);

        }
        else
        {

            this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle + 90);
        }
        Debug.Log(angle);
        this.gameObject.transform.position = new Vector3(myTurret.gameObject.transform.position.x + myTurret.actualDir.x * ratio,
            myTurret.gameObject.transform.position.y + myTurret.actualDir.y * ratio,
            0
            );
    }
}
