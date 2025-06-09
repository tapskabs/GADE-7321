using UnityEngine;

public class RacerProgress : MonoBehaviour
{
    public int checkpointsPassed = 0;
    public Transform nextWaypoint;
    public float distanceToNext;

    public int currentWaypointIndex = 0;

    private void Start()
    {
        if (WaypointManager.instance != null && WaypointManager.instance.waypoints.Count > 0)
        {
            nextWaypoint = WaypointManager.instance.waypoints[0];
        }
    }

    public void PassedWaypoint()
    {
        checkpointsPassed++;
        currentWaypointIndex = (currentWaypointIndex + 1) % WaypointManager.instance.waypoints.Count;
        nextWaypoint = WaypointManager.instance.GetNextWaypoint(currentWaypointIndex);
    }

    public void UpdateDistance()
    {
        if (nextWaypoint != null)
        {
            distanceToNext = Vector3.Distance(transform.position, nextWaypoint.position);
        }
    }
}
