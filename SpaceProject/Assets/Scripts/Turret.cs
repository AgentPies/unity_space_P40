using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float detectionRange = 10f;
    public Transform target;
    public Collider roomCollider;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float bulletSpeed = 10f;

    private bool isInRoom;
    private float nextFireTime;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isInRoom = false;
        nextFireTime = Time.time; // Initialize the next fire time to the current time
    }

    private void Update()
    {
        // Check if the target is within detection range and in the same room
        if (Vector3.Distance(transform.position, target.position) <= detectionRange && isInRoom)
        {

            // Rotate to face the target
            transform.LookAt(target);

            // Fire bullets if the next fire time has been reached
            if (Time.time >= nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + 1f / fireRate; // Update the next fire time
            }
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

    private void FireBullet()
    {
        // Instantiate a bullet at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody component of the bullet
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Set the velocity of the bullet using bulletSpeed
        bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;
    }
}
