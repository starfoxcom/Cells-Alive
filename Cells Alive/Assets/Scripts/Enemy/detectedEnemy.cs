using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectedEnemy : MonoBehaviour
{
  // Start is called before the first frame update
  public SphereCollider bloodCell;
  public GlobuloRojo []RedCell;
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
        bloodCell.gameObject.GetComponent<BloodCell>().live -= 5;
      }
        RedCell=FindObjectsOfType<GlobuloRojo>();
        for (int i = 0; i < RedCell.Length; i++)
        {
            if (GetComponent<SphereCollider>().bounds.Intersects(RedCell[i].GetComponent<CircleCollider2D>().bounds))
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
