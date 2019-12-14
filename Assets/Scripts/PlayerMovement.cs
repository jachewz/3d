using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float DashSpeed = 10f;
    public float MaxDashTime = 3f;
    public Vector3 Drag;
    public int MaxJumps = 2;

    float camRayLength = 100f;
    int floorMask;

    private CharacterController _controller;
    private Vector3 _velocity;
    private float _currentDashTime;
    private int _jumps = 0;


    void Start()
    {
        floorMask = LayerMask.GetMask("Ground");
        _controller = GetComponent<CharacterController>();
        _currentDashTime = MaxDashTime;

    }

    void Update()
    {

        if (_controller.isGrounded)
        {
            _velocity.y = 0f;
            _jumps = 0;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
            transform.forward = move;

        if (Input.GetButtonDown("Jump") && _jumps < MaxJumps)
        {
            _jumps++;
            _velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        LookAtMouse();


        _velocity.y += Gravity * Time.deltaTime;

        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);

        if (Input.GetButtonDown("Dash"))
        {
            Debug.Log("Dash");
            _currentDashTime = 0;
        }

        if (_currentDashTime < MaxDashTime)
        {
            _currentDashTime += Time.deltaTime;
            _controller.Move(transform.forward * Time.deltaTime * DashSpeed);
        }

    }

    void LookAtMouse()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            transform.rotation = newRotation;
        }
    }

}

