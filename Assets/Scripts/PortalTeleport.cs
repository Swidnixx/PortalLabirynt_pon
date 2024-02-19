using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform receiver;
    Transform player;

    private void FixedUpdate()
    {
        if(player)
        {
            Vector3 portal_forward = transform.up;
            Vector3 portal_to_player = player.position - transform.position;
            float dot = Vector3.Dot(portal_forward, portal_to_player);
            if(dot < 0)
            {
                //teleporting
                player.position = receiver.position;
                Vector3 player_forward = player.forward;
                player_forward = transform.parent.InverseTransformDirection(player_forward);
                player_forward = receiver.parent.TransformDirection(player_forward);
                player.forward = player_forward;

                player = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
