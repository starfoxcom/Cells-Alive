using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTorret : MonoBehaviour
{
    public Turret[] torres= {new Turret(), new Turret(), new Turret(), new Turret() };
    public int Ammunition;
    //public bool healingAmmunition = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    torres[0].isActive = true;
        //    torres[1].isActive = false;
        //    torres[2].isActive = false;
        //    torres[3].isActive = false;
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    torres[0].isActive = false;
        //    torres[1].isActive = true;
        //    torres[2].isActive = false;
        //    torres[3].isActive = false;
        //}
        //else if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    torres[0].isActive = false;
        //    torres[1].isActive = false;
        //    torres[2].isActive = true;
        //    torres[3].isActive = false;
        //}
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    torres[0].isActive = false;
        //    torres[1].isActive = false;
        //    torres[2].isActive = false;
        //    torres[3].isActive = true;
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //
        //}
    }
}
