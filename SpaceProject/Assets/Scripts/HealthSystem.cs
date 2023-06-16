using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerShooting>().enabled = false;
            GetComponent<Animator>().SetBool("IsDead", true);   
            Invoke("DestroyEnemy", 3f);
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
        }
    }

    public void Heal(int heal)
    {
        Debug.Log("Heal");
        if (currentHealth + heal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal;
        }
        healthBar.SetHealth(currentHealth);
    }


}
