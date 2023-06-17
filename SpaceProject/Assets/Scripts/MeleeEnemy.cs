using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public GameObject currentRoom;
    public Collider enemyCollider; // Collider representing the enemy

    private GameObject player;
    private Rigidbody rb;
    private bool isPlayerInRoom;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        isPlayerInRoom = false;
    }

    private void FixedUpdate()
    {
        DetectPlayer();

        if (isPlayerInRoom)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.MoveRotation(rotation);
            rb.MovePosition(rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);
            this.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }

    private void DetectPlayer()
    {
        if (player.GetComponent<PlayerMovement>().GetCurrentRoom() == currentRoom)
        {
            isPlayerInRoom = true;
        }
        else
        {
            isPlayerInRoom = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //  && collision.collider == enemyCollider
        if (collision.collider.CompareTag("Player"))
        {
            this.GetComponent<Animator>().Play("MeleeAttack");
            DamagePlayer(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            currentRoom = null;
        }
    }

    private void DamagePlayer(GameObject player)
    {
        if (player.CompareTag("Player"))
        {
            player.GetComponent<HealthSystem>().TakeDamage(20);
            Debug.Log("Player damaged by melee enemy!");
        }
    }
}
