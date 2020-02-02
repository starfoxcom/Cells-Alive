using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modul : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isActive = false;
    public Modul mymodul;
    public InputManager input;
    public MovimientoInter myManager;
    float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PauseMenu pause = FindObjectOfType<PauseMenu>();
        //if (pause.GameIsPaused)
        //{
        //    mymodul.isActive = false;
        //    return;
        //}
    }
    public void onUpdate()
    {
        myManager.isActive = false;
        mymodul.isActive = true;
        mymodul.input = input;
        if (input.AccionButton()&&time>0.2f)
        {
            time = 0;
            myManager.isActive = true;
            myManager.m_OnModule = false;
            mymodul.isActive = false;
        }
        time += Time.deltaTime;
    }
}
