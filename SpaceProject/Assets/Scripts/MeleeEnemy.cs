using UnityEngine;

public class MeleeEnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public Transform target;
    public Collider roomCollider;

    private bool isInRoom;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isInRoom = false;
    }

    private void Update()
    {
        // Check if the target is within detection range and in the same room
        if (Vector3.Distance(transform.position, target.position) <= detectionRange && isInRoom)
        {
            this.GetComponent<Animator>().SetBool("isWalking", true);
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the enemy enters a room
        if (other == roomCollider)
        {
            isInRoom = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the enemy exits a room
        if (other == roomCollider)
        {
            isInRoom = false;
        }
    }
}