using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDectector : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if we collided with a wall or another racer
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Racer"))
        {
            SFXManager.Instance.PlaySFX("crash", 3f);
            Debug.Log("Crash detected with: " + collision.collider.name);
        }
    }
}
