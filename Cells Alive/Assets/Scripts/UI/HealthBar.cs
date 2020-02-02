using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform HealthB;
    [SerializeField] public float Health;
    [SerializeField] public float Speed;

    float maxHealth = 100f;
    bool BoModVida = true;
    float ModVida, VidaCambio;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(float a)
    {
        /*Health = Mathf.Clamp(Health - 10, 0f, maxHealth);
        Health += Speed * Time.deltaTime;
        HealthB.GetComponent<Image>().fillAmount = Health / maxHealth;*/
        BoModVida = true;
        ModVida -= a;
    }

    public void TakeHeal(float a)
    {
        /*Health = Mathf.Clamp(Health + 10, 0f, maxHealth);
        Health += Speed  * Time.deltaTime;
        HealthB.GetComponent<Image>().fillAmount = Health / maxHealth;*/
        BoModVida = true;
        ModVida += a;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeHeal(10);
        }
        if (BoModVida)
        {
            float ModAnt = ModVida;
            //VidaCambio += Time.deltaTime * ModVida * Speed;
            ModVida -= Time.deltaTime * ModVida * Speed;
            Health = Mathf.Clamp(Health + Time.deltaTime * ModVida * Speed, 0f, maxHealth);
            //Health += Speed * Time.deltaTime;
            HealthB.GetComponent<Image>().fillAmount = Health / maxHealth;
            //if (Mathf.Abs(VidaCambio) >= Mathf.Abs(ModVida))
            if (Mathf.Abs(ModAnt) <= Mathf.Abs(ModVida))
            {
                BoModVida = false;
                VidaCambio = 0;
                ModVida = 0;
            }
        }
    }
}

//Creditos a Maradona