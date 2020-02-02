using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herida : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float porcentaje = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float normalize = porcentaje / 100;
        float porSiAcaso = normalize;
        if(normalize < 0.2)
        {
            porSiAcaso = 0.3f;
        }
        sprite.color = new Color(normalize, normalize, normalize, porSiAcaso);
        if (normalize<=0)
        {
            FindObjectOfType<Win>().numheridas--;
            Destroy(this.gameObject);
        }

    }
}
