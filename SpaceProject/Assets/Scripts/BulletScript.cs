using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10f; // Speed of the bullet
    public float bulletLifetime = 2f; // Time before the bullet is destroyed

    void Start()
    {
        // Set a timer to destroy the bullet after the specified lifetime
        Destroy(gameObject, bulletLifetime);
    }

    void FixedUpdate()
    {
        // Move the bullet forward based on its speed
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collides with an enemy or any other object that should be destroyed
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject); // Destroy the collided object
            Destroy(gameObject); // Destroy the bullet
        }
    }
}