using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Ammo
{
    public GameObject a_Obj;
    public void CreateAmmo(Sprite a_Texture)
    {
        a_Obj = new GameObject();
        a_Obj.AddComponent<SpriteRenderer>();
        a_Obj.GetComponent<SpriteRenderer>().sprite = a_Texture;
        a_Obj.AddComponent<BoxCollider>();
        a_Obj.transform.localScale = new Vector3(.2f, .2f, .2f);
    }
}
[System.Serializable]
public class Zones
{
    public GameObject z_Obj;
    [HideInInspector]
    public List<Ammo> z_Ammos;
    float z_Time;
    public float z_Radius, z_LimitTime;
    bool z_StillAmmos;
    public void Update(Sprite Texture)
    {
        z_Time += Time.deltaTime;
        if (z_Time >= z_LimitTime)
        {
            if (!z_StillAmmos)
            {
                for (int i = 0; i <= Mathf.Floor(Random.value * 3); i++)
                {
                    z_Ammos.Add(new Ammo());
                    z_Ammos[z_Ammos.Count - 1].CreateAmmo(Texture);
                    z_Ammos[z_Ammos.Count - 1].a_Obj.transform.position = new Vector3(Random.value * z_Radius * (Mathf.Floor(Random.value * 2) == 0 ? 1 : -1), Random.value * z_Radius * (Mathf.Floor(Random.value * 2) == 0 ? 1 : -1), 0) + z_Obj.transform.position;
                }
            }
            else
            {
                foreach (Ammo ammo in z_Ammos)
                {
                    GameObject.Destroy(ammo.a_Obj);
                }
                z_Ammos.Clear();
            }
            z_StillAmmos = !z_StillAmmos;
            z_Time = 0;
        }
        GameObject PJ = GameObject.FindWithTag("BloodCell");
        for (int i = 0; i < z_Ammos.Count; i++)
        {
            if (Mathf.Pow(Mathf.Pow(PJ.transform.position.x - z_Ammos[i].a_Obj.transform.position.x, 2) + Mathf.Pow(PJ.transform.position.y - z_Ammos[i].a_Obj.transform.position.y, 2), .5f) <= 2)
            {
                PJ.GetComponent<ChangeTorret>().Ammunition += 10;
                GameObject.Destroy(z_Ammos[i].a_Obj);
                z_Ammos.Remove(z_Ammos[i]);
                break;
            }
        }
        if (z_StillAmmos && z_Ammos.Count == 0)
        {
            z_StillAmmos = false;
            z_Time = 0;
        }
    }
    public void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(z_Obj.transform.position, z_Radius);
    }
}

public class Municion : MonoBehaviour
{
    public List<Zones> m_Zones;
    public Sprite m_Texture;
    void Update()
    {
        foreach(Zones z in m_Zones)
        {
            z.Update(m_Texture);
        }
    }
    void OnDrawGizmos()
    {
        foreach (Zones z in m_Zones)
        {
            z.OnDrawGizmos();
        }
    }
}