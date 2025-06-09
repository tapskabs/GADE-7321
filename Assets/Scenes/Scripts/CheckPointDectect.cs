using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointDectect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            Object.FindFirstObjectByType<CheckpointManager>().CheckpointReached(gameObject);
        }
    }
}
