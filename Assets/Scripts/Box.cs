using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IKillable
{
    public int HitPoints = 100;

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Damage(int damageValue)
    {
        HitPoints -= damageValue;
        if (HitPoints<=0)
        {
            Kill();
        }
    }
}
