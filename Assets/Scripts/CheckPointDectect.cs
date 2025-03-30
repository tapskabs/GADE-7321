using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDectect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure it's the player
        {
            FindObjectOfType<CheckpointManager>().CheckpointReached(gameObject);
        }
    }
}
