using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 100);
        rand = 100;
        if (rand > 70)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthSystem>().Heal(20);
            Destroy(this.gameObject);
        }
    }
}
