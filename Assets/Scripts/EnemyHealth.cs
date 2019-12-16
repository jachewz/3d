using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HitPoints = 100f;
    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Damage(float damageValue)
    {
        HitPoints -= damageValue;
        Debug.Log("Dealt " + damageValue + "damage, enemy current hp:" + HitPoints);
        if (HitPoints <= 0)
        {
            Kill();
        }
    }
}
