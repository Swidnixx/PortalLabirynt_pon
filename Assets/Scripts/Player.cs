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
        GroundCheck();
        Jump();
    }
    public LayerMask walkableMask;
    public float regularSpeed = 7.7f;
    public float fastSpeed = 11.1f;
    public float slowSpeed = 4.9f;
    public float airSpeed = 1.22f;
    void GroundCheck()
    {
        RaycastHit hit;
        Physics.SphereCast(transform.position, 0.501f, Vector3.down, out hit,  1 - 0.501f + 0.2f, walkableMask);
        if (hit.collider == null)
        {
            speed = airSpeed;
            return;
        }
        switch(hit.collider.tag)
        {
            case "Fast":
                speed = fastSpeed; break;
            case "Slow":
                speed = slowSpeed; break;
            default:
                speed = regularSpeed; break;
        }
    }

    bool grounded;
    float velocity_y;
    void Jump()
    {

        var col = controller.Move(Vector3.up * velocity_y * Time.deltaTime);
        grounded = (col & CollisionFlags.Below) != 0 && velocity_y < 0;
        bool jumpInput = Input.GetButton("Jump");

        if(grounded)
        {
            if (jumpInput)
                velocity_y = 7;
            else
                velocity_y = 0;
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
