using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] public bool ranged = false;
    [SerializeField] public bool melee = false;
    [SerializeField] public bool turret = false;
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
        if (melee)
        {
            this.GetComponent<MeleeEnemy>().enabled = false;
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }
        else if (ranged)
        {
            this.GetComponent<RangedEnemy>().enabled = false;

        }
        else if (turret)
        {
            this.GetComponent<Turret>().enabled = false;
        }
        if (turret != true)
        {
            this.GetComponent<Animator>().Play("death");
        }
        
        this.GetComponent<Collider>().enabled = false;
        
        Invoke("DestroyEnemy", 3f);
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

}
