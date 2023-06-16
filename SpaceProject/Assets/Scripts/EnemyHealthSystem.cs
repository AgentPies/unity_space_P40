using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] public bool ranged = false;
    [SerializeField] public bool melee = false;
    [SerializeField] public bool turret = false;
    [SerializeField] public ParticleSystem deathParticle;
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
        this.GetComponent<Collider>().enabled = false;    
        if (melee)
        { 
            this.GetComponent<Animator>().Play("death");
            this.GetComponent<MeleeEnemy>().enabled = false;
            this.GetComponent<Animator>().SetBool("isWalking", false);
            Destroy(this.gameObject, 3f);

        }
        else if (ranged)
        {
            this.GetComponent<Animator>().Play("death");
            this.GetComponent<RangedEnemy>().enabled = false;
            Destroy(this.gameObject, 3f);

        }
        else if (turret)
        {
            this.GetComponent<Turret>().enabled = false;
            if (!deathParticle.isPlaying) {
                deathParticle.Play();
            }
            Destroy(this.gameObject, deathParticle.main.duration);
        }
        
    }

}
