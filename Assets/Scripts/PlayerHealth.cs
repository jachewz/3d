using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float HitPoints = 100f;
    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Damage(float damageValue)
    {
        HitPoints -= damageValue;
        if (HitPoints <= 0)
        {
            Kill();
        }
    }
}
