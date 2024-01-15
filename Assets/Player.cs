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
        // tak jak ruch lewo prawo
        float inputx = Input.GetAxis("Horizontal");

        // zrobi� jeszcze ruch prz�d ty�

        transform.position += new Vector3(inputx, 0, 0);
    }
}
