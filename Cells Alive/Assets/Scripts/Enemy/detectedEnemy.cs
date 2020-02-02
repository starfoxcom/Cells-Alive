using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectedEnemy : MonoBehaviour
{
  // Start is called before the first frame update
  public SphereCollider bloodCell;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    bloodCell = FindObjectOfType<BloodCell>().GetComponent<SphereCollider>();
      if (GetComponent<SphereCollider>().bounds.Intersects(bloodCell.bounds))
      {
        Destroy(this.gameObject);
      }
    }
}
