using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    float Tiempo = 0;
    void Update()
    {
        Tiempo += Time.deltaTime;
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length <= Tiempo)
            SceneManager.LoadScene("Menu");
    }
}
