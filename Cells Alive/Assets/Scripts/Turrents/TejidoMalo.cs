using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TejidoMalo : MonoBehaviour
{
    // Start is called before the first frame update
    public float porcentaje=0;
    float red;
    void Start()
    {
        red = this.GetComponent<SpriteRenderer>().color.r;

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(red - porcentaje,porcentaje,0,255);
    }
   
}
