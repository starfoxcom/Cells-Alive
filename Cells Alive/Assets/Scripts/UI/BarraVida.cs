using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Scrollbar HealthBar;
    float Health, maxHealth = 100f;

    void Start()
    {
        Health = maxHealth;
    }
    public void TakeDamage()
    {
        Health = Mathf.Clamp(Health - 10, 0f, maxHealth);
        HealthBar.size = Health / maxHealth;
    }

    public void TakeHealth()
    {
        Health = Mathf.Clamp(Health + 10, 0f, maxHealth);
        HealthBar.size = Health / maxHealth;
    }

}
