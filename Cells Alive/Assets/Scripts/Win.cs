using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public int numheridas;
    // Start is called before the first frame update
    void Start()
    {
        numheridas = FindObjectsOfType<herida>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (numheridas<=0)
        {
            //FindObjectOfType<PauseMenu>().ReturnMenu();
            SceneManager.LoadScene("Creditos");
        }
    }
}
