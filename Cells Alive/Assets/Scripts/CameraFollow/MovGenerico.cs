using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGenerico : MonoBehaviour
{
    float VX, VY;
    public int m_Ammunition;
    void Update()
    {
        VX = 0;
        VY = 0;
        if (Input.GetKey(KeyCode.W))
        {
            VY += 6;
        }
        if (Input.GetKey(KeyCode.A))
        {
            VX -= 6;
        }
        if (Input.GetKey(KeyCode.S))
        {
            VY -= 6;
        }
        if (Input.GetKey(KeyCode.D))
        {
            VX += 6;
        }
        transform.Translate(VX * Time.deltaTime, VY * Time.deltaTime, 0);
    }
}
