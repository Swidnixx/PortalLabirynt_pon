using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    bool grounded;
    float velocity_y;
    void Jump()
    {

        var col = controller.Move(Vector3.up * velocity_y * Time.deltaTime);
        grounded = (col & CollisionFlags.Below) != 0;
        bool jumpInput = Input.GetButton("Jump");

        if(jumpInput && grounded)
        {
            velocity_y = 7;
        }

        velocity_y += Physics.gravity.y * Time.deltaTime;

    }
    void Movement()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float inputy = Input.GetAxisRaw("Vertical");

        Vector3 right = transform.right * inputx;
        Vector3 forward = transform.forward * inputy;
        Vector3 motion = forward + right;

        motion = motion.normalized;
        motion *= Time.deltaTime * speed;
        controller.Move(motion);
    }
}
