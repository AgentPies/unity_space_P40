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

    IEnumerator EnemyDieCoroutine()
    {
        yield return new WaitForSeconds(5f);
    }
    public void EnemyDie()
    { 
        this.GetComponent<RangedEnemy>().enabled = false;
        this.GetComponent<Animator>().SetBool("IsDead", true);
        
        EnemyDieCoroutine();
        Destroy(this.gameObject);
    }

}
