using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.transform.parent.transform.parent.GetComponent<Room>().ContainsEnemy()
            && this.transform.parent.transform.parent.GetComponent<Room>().ContainsPlayer())
            {
                return;
            }
            doorAnimator.Play("DoorOpen", 0, 0.0f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (this.transform.parent.transform.parent.GetComponent<Room>().ContainsEnemy()
            && this.transform.parent.transform.parent.GetComponent<Room>().ContainsPlayer())
            {
                return;
            }
            doorAnimator.Play("DoorClose", 0, 0.0f);
        }
    }

}
