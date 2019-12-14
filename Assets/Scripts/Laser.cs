using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float MaxLaserDistance = 100f;
    public float DamageValue = 1f;
    public float Force = 10f;
    LineRenderer line;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");

        }
        
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while(Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            line.SetPosition(0, ray.origin);
            if (Physics.Raycast(ray, out RaycastHit hit, MaxLaserDistance))
            {
                line.SetPosition(1, hit.point);
                if(hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * Force, hit.point);
                    if(hit.rigidbody.gameObject.tag == "Enemy")
                    {
                        hit.rigidbody.gameObject.GetComponent<EnemyHealth>().Damage(DamageValue);
                    }
                }
            }
            else
                line.SetPosition(1, ray.GetPoint(MaxLaserDistance));


            yield return null;

        }

        line.enabled = false;
    }
}
