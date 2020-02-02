using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMunation : MonoBehaviour
{
    public int numAdd=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BloodCell")
        {
            if (FindObjectOfType<ChangeTorret>().Ammunition > 1000)
            {
                return;
            }
            FindObjectOfType<ChangeTorret>().Ammunition += numAdd;
            if (FindObjectOfType<ChangeTorret>().Ammunition>1000)
            {
                FindObjectOfType<ChangeTorret>().Ammunition = 1000;
            }
            Destroy(this.gameObject);
        }
    }
}
