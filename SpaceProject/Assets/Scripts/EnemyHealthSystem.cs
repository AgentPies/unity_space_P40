using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (this.gameObject.tag == "Enemy")
        {
            if (currentHealth <= 0)
            {
                EnemyDie();
            }
        }
    }


    public void EnemyDie()
    { 
        if (this.gameObject.name == "MeleeEnemy")
        {
            this.GetComponent<MeleeEnemy>().enabled = false;
            this.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else if (this.gameObject.name == "RangedEnemy")
        {
            this.GetComponent<RangedEnemy>().enabled = false;
        }
        else if (this.gameObject.name == "Turret")
        {
            this.GetComponent<Turret>().enabled = false;
        }
        if (this.gameObject.name != "Turret")
        {
            this.GetComponent<Animator>().Play("death");
        }
        
        this.GetComponent<Collider>().enabled = false;
        
        Invoke("DestroyEnemy", 5f);
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

}
