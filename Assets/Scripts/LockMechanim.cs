using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public KeyColor keyColor;
    public Animator animator;
    public DoorMechanim[] doorToOpen;

    bool playerInRange = false;

    private void Update()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if ( GameManager.Instance.HasKey(keyColor) )
                {
                    animator.SetTrigger("open");
                    GameManager.Instance.UseKey(keyColor);
                }
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void OpenDoor()
    {
        foreach( var d in doorToOpen )
        {
            d.is_open = true;
        }
    }
}
