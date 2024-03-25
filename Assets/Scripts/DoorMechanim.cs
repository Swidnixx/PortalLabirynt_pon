using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public bool is_open;
    public Transform door, closedPos, openPos;
    public float speed = 1;

    private void Start()
    {
        door.position = is_open ? openPos.position : closedPos.position;
    }

    private void Update()
    {
        Vector3 target_pos = is_open ? openPos.position : closedPos.position;
        door.position = Vector3.MoveTowards(door.position, target_pos, Time.deltaTime * speed);
    }
}
