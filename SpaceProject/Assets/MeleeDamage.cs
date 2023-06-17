using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    
    private void OnTriggerEnter(Collision other)
    {
        //  && collision.collider == enemyCollider
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Melee enemy collided with player!");
            this.transform.parent.gameObject.GetComponent<Animator>().Play("MeleeAttack");
            DamagePlayer(other.gameObject);
        }
    }
        private void DamagePlayer(GameObject player)
    {
        player.GetComponent<HealthSystem>().TakeDamage(20);
        Debug.Log("Player damaged by melee enemy!");
     
    }
}
