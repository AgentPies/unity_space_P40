using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public string currentRoom;

    private Rigidbody rb;
    private Camera cam;

    private Vector3 movement;
    private Vector3 mousePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsRunning", false);
        }
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector3 lookDir = mousePos - rb.position;
        lookDir.y = 0f; // Ensure the player doesn't tilt based on the mouse position
        Quaternion rotation = Quaternion.LookRotation(lookDir);
        rb.MoveRotation(rotation);
    }

    public string GetCurrentRoom()
    {
        return currentRoom;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = other.gameObject.name; // Assign the name of the entered room as the current room identifier
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = null; // Reset the current room identifier when exiting the room
        }
    }
}
