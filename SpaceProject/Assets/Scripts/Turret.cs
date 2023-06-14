using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate = 1f; // Number of bullets fired per second
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string currentRoom;

    private Rigidbody rb;
    private GameObject player;
    private bool isPlayerInRoom;
    private float fireCooldown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        DetectPlayer();

        if (fireCooldown <= 0f && isPlayerInRoom)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(rotation);
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;
    }

    private void DetectPlayer()
    {
        if (player.GetComponent<PlayerMovement>().GetCurrentRoom() == currentRoom)
        {
            Vector3 direction = player.transform.position - transform.position;
            
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
