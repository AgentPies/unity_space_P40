using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public string currentRoom;

    private Rigidbody rb;
    private GameObject player;
    private bool isPlayerInRoom;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        DetectPlayer();

        if (isPlayerInRoom)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(rotation);  
        }
    }


    private void DetectPlayer()
    {
        if (player.GetComponent<PlayerMovement>().GetCurrentRoom() == currentRoom)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.MovePosition(rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);
            isPlayerInRoom = true;
        }
        else
        {
            isPlayerInRoom = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = other.gameObject.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = null;
        }
    }
}
