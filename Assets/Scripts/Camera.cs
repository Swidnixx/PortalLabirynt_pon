using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float leftRightSpeed = 350;
    public float upDownSpeed = 350;

    float cameraRotX = 0;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        Transform player = transform.parent;
        float leftRight = mouse_x * Time.deltaTime * leftRightSpeed;
        player.Rotate(0, leftRight, 0);

        cameraRotX -= mouse_y * Time.deltaTime * upDownSpeed;
        cameraRotX = Mathf.Clamp(cameraRotX, -90, 60);
        transform.localRotation = Quaternion.Euler(new Vector3(cameraRotX, 0, 0));
    }
}
