using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;

    private Room currentRoom;
    private bool isChasingPlayer;
    private float nextFireTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isChasingPlayer = false;
        nextFireTime = Time.time;
    }

    private void Update()
    {
        if (isChasingPlayer)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            this.GetComponent<Animator>().SetBool("IsRunning", true);

            // Rotate to face the player
            transform.LookAt(player.transform);

            // Fire bullets if the next fire time has been reached
            if (Time.time >= nextFireTime)
            {
                this.GetComponent<Animator>().SetBool("IsShooting", true);
                FireBullet();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            Room enteredRoom = other.GetComponent<Room>();
            if (enteredRoom != null)
            {
                currentRoom = enteredRoom;
                isChasingPlayer = currentRoom.ContainsPlayer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            Room exitedRoom = other.GetComponent<Room>();
            if (exitedRoom == currentRoom)
            {
                currentRoom = null;
                isChasingPlayer = false;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;
    }
}
