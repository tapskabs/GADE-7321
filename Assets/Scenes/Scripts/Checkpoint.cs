using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RacerProgress progress = other.GetComponent<RacerProgress>();
        if (progress != null && transform == progress.nextWaypoint)
        {
            progress.PassedWaypoint();
        }
    }
}
