using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private List<Collider> collidersInRoom = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (!collidersInRoom.Contains(other))
        {
            collidersInRoom.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidersInRoom.Contains(other))
        {
            collidersInRoom.Remove(other);
        }
    }

    public bool ContainsPlayer()
    {
        foreach (Collider collider in collidersInRoom)
        {
            if (collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
