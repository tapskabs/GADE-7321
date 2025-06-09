using System.Collections.Generic;
using UnityEngine;

public class AdvancedRacerTracker : MonoBehaviour
{
    public int racerID; // 0 = player, 1+ = AI
    public int waypointsPassed = 0;
    public int lap = 1;

    public GraphNode currentNode;
    public GraphNode nextNode;

    public void PassWaypoint(GraphNode node)
    {
        if (node == nextNode)
        {
            waypointsPassed++;

            if (waypointsPassed % 13 == 0) // Change if more/fewer waypoints per lap
            {
                lap = Mathf.Min(3, lap + 1);
            }

            currentNode = nextNode;
            if (nextNode.neighbours.Count > 0)
            {
                nextNode = nextNode.neighbours[Random.Range(0, nextNode.neighbours.Count)];
            }
        }
    }

    public float DistanceToNext()
    {
        if (nextNode == null) return float.MaxValue;
        return Vector3.Distance(transform.position, nextNode.waypoint.position);
    }
    public Vector3 GetNextWaypoint()
    {
        return currentNode?.waypoint.position ?? transform.position;
    }
}
