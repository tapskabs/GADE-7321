using UnityEngine;

public class RacerProgress : MonoBehaviour
{
    public int waypointsPassed = 0;
    public Transform nextWaypoint;

    public void PassedWaypoint(Transform newWaypoint)
    {
        waypointsPassed++;
        nextWaypoint = newWaypoint;
    }
}
