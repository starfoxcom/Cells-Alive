using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 rayUp;
    public Vector2 rayDown;
    public Vector2 rayLeft;
    public Vector2 rayRight;
    public Vector2 rayupRight;
    public Vector2 rayDownRight;
    public Vector2 rayUpLeft;
    public Vector2 rayDownLeft;
    public float ratio = 29;
    void Start()
    {
        rayUp = new Vector2(0,1);
        rayDown = new Vector2(0, -1);
        rayLeft = new Vector2(-1, 0);
        rayRight = new Vector2(1, 0);
        rayupRight = new Vector2(1, 1);
        rayupRight.Normalize();
        rayDownRight = new Vector2(1, -1);
        rayDownRight.Normalize();
        rayUpLeft = new Vector2(-1, 1);
        rayUpLeft.Normalize();
        rayDownLeft = new Vector2(-1,-1);
        rayDownLeft.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        checkCollision(rayUp);
        checkCollision(rayDown);
        checkCollision(rayRight);
        checkCollision(rayLeft);
        checkCollision(rayupRight);
        checkCollision(rayDownRight);
        checkCollision(rayUpLeft);
        checkCollision(rayDownLeft);
       
    }

    void checkCollision(Vector2 dir)
    {
        RaycastHit2D[] rayhit=null;
        rayhit=Physics2D.RaycastAll(this.gameObject.transform.position, dir, ratio);
        for (int i = 0; i < rayhit.Length; i++)
        {
            if (rayhit[i].collider != null && rayhit[i].collider.tag == "MapWall")
            {

                Vector3 vec = this.gameObject.transform.position;
                vec -= new Vector3(rayhit[i].point.x, rayhit[i].point.y, 0);
                vec.z = 0;
                vec.Normalize();
                this.gameObject.transform.position = new Vector3(
                   rayhit[i].point.x + (vec.x * ratio),
                   rayhit[i].point.y + (vec.y * ratio),
                    this.gameObject.transform.position.z
                    );
            }
        }
        
    }
}
