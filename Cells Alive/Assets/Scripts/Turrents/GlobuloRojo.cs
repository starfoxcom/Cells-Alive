using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobuloRojo : MonoBehaviour
{
    GameObject myObject;
    public Vector2 direction;
    public float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        myObject = GetComponent<GameObject>();

        // Kills the game object in 5 seconds after loading the object
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + (direction.x * speed),
            this.transform.position.y + (direction.y * speed),
            this.transform.position.z);
       RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, 0.00002f);
       if (hit.collider != null && hit.collider.gameObject.tag == "Virus")
       {
           //hit.collider.gameObject.GetComponent<TejidoMalo>().porcentaje += 0.02f;
           
           Destroy(hit.collider.gameObject);
           Destroy(this.gameObject);
       }
    }
}
