using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager instance;

    public List<Transform> waypoints = new List<Transform>();

    void Awake()
    {
        if (instance == null)
            instance = this;

        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");

        // Sort waypoints by name (make sure they are named in order: Waypoint0, Waypoint1, ...)
        System.Array.Sort(waypointObjects, (a, b) => a.name.CompareTo(b.name));

        foreach (var wp in waypointObjects)
        {
            waypoints.Add(wp.transform);
        }
    }

    public Transform GetNextWaypoint(int currentIndex)
    {
        int nextIndex = (currentIndex + 1) % waypoints.Count;
        return waypoints[nextIndex];
    }

    public int GetWaypointIndex(Transform waypoint)
    {
        return waypoints.IndexOf(waypoint);
    }
}
