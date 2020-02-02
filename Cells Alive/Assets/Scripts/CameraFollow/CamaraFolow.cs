using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script goes in the camera

public class CamaraFolow : MonoBehaviour
{
    public GameObject m_Cell;
    Vector3 m_Movement, m_Offset;
    private void Start()
    {
        m_Offset = transform.position - m_Cell.transform.position;
    }
    void LateUpdate()
    {
        Vector3 DesiredPos = m_Cell.transform.position + m_Offset + m_Movement;
        transform.position = Vector3.Lerp(transform.position, DesiredPos, .25f);
    }
    public void MoveCamera(Vector2 Movement)
    {
        m_Movement += new Vector3(Movement.x, Movement.y, 0);
    }
    public void ZoomCamera(float NewHigh)
    {
        m_Movement += new Vector3(0, 0, NewHigh);
    }
}
