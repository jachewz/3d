using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour
{

    public Animator Animator;
    public Collider Weapon;
    public LayerMask AttackableLayers;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
        }
    }

    void Attack()
    {

        Weapon.enabled = true;
        Animator.SetTrigger("Swing");

        
    }


}
