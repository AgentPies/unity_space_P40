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
            // this.GetComponent<Animator>().SetBool("isWalking", true);
            // this.GetComponent<Animator>().Play("SwordRun");
            // AnimationClip[] clips = this.GetComponent<Animator>().runtimeAnimatorController.animationClips;
            // Debug.Log(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SwordRun"));
            if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SwordRun") == false)
            {
                this.GetComponent<Animator>().Play("SwordRun");
            }

        }
        else
        {

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
            this.GetComponent<Animator>().Play("Idle");
            isPlayerInRoom = false;
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
}
