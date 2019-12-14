using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public Transform player;
    //public Vector3 offset = new Vector3(0, 45, -20);

    //// // Start is called before the first frame update
    //// void Start()
    //// {

    //// }

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.position = player.position + offset;
    //}

    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.

    Vector3 offset;                     // The initial offset from the target.

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.fixedDeltaTime);
    }
}
