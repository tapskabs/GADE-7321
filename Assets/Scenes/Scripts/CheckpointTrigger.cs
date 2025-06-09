using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private CheckpointManager manager;

    void Start()
    {
       
        manager = Object.FindFirstObjectByType<CheckpointManager>();
        if (manager == null)
        {
            Debug.LogError("CheckpointManager not found in scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player reached checkpoint: " + gameObject.name);
            manager.CheckpointReached(gameObject);
        }
    }
}
