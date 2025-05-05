using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LinkedList;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{

    public float speed = 3.5f;
    public LinkedListNode<Transform> currentWaypoint;
    public int waypointsPassed = 0;
    public Transform nextWaypoint;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextDestination();
    }

    void SetNextDestination()
    {
        if (currentWaypoint != null)
        {
            agent.SetDestination(currentWaypoint.Value.position);
            nextWaypoint = currentWaypoint.Value;
        }
    }

    public void AdvanceToNextWaypoint()
    {
        if (currentWaypoint != null)
        {
            waypointsPassed++;

            currentWaypoint = currentWaypoint.Next ?? RaceManager.Instance.waypoints.First;
            SetNextDestination();
        }
    }

    public float DistanceToNextWaypoint()
    {
        if (nextWaypoint == null) return float.MaxValue;
        return Vector3.Distance(transform.position, nextWaypoint.position);
    }
}
