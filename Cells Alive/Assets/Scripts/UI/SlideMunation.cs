using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMunation : MonoBehaviour
{
    public Slider slider;
    public ChangeTorret munation;
    // Use this for initialization
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = munation.Ammunition;
    }
}
