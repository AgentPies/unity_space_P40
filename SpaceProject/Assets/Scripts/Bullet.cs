using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifetime = 3f; // Time in seconds before the bullet disappears
    [SerializeField] bool PlayerShooter = false; // The object that shot the bullet

    private void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet hit: " + collision.gameObject.name);

        if (!collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);

            
        }
        if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<HealthSystem>().TakeDamage(20);
            }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (PlayerShooter)
            {
                collision.gameObject.GetComponent<EnemyHealthSystem>().TakeDamage(10);
            }
        }
    }

    public void SetPlayerShooter(bool playerShooter)
    {
        PlayerShooter = playerShooter;
    }
}

