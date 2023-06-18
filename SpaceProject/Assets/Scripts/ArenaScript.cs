using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    public int round = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(round);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            round++;
            SpawnEnemies(round);
        }
    }

    void SpawnEnemies(int round)
    {
        foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door")){
            if (round == 1){
                door.GetComponent<Animator>().Play("ArenaDoorOpen");
                GameObject enemy = _enemies[0];
                Instantiate(enemy, door.transform.position, Quaternion.identity);
                enemy.GetComponent<Transform>().localScale = new Vector3(4,4,4);
                Instantiate(enemy, door.transform.position, Quaternion.identity);
                enemy.GetComponent<Transform>().localScale = new Vector3(4,4,4);
                Invoke("ArenaDoorClose", 1f);   
            }
            else if (round == 2)
            foreach (GameObject enemy in _enemies)
                {
                    door.GetComponent<Animator>().Play("ArenaDoorOpen");
                    Instantiate(enemy, door.transform.position, Quaternion.identity);
                    enemy.GetComponent<Transform>().localScale = new Vector3(4,4,4);
                    Invoke("ArenaDoorClose", 1f);
                    
                }
            else if (round == 3)
            {
                door.GetComponent<Animator>().Play("ArenaDoorOpen");
                GameObject enemy = _enemies[1];
                Instantiate(enemy, door.transform.position, Quaternion.identity);
                enemy.GetComponent<Transform>().localScale = new Vector3(4,4,4);
                Instantiate(enemy, door.transform.position, Quaternion.identity);
                enemy.GetComponent<Transform>().localScale = new Vector3(4,4,4);
                Invoke("ArenaDoorClose", 1f);
            }
            else if (round == 4)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
            }
        }

    }

    void ArenaDoorClose()
    {
        foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door"))
        {
            door.GetComponent<Animator>().Play("ArenaDoorClose");
        }
    }
}
