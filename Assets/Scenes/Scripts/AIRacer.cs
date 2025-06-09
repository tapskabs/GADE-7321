using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static LinkedList;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent agent;
    private CustomLinkedList waypointsList;
    private Node currentNode;

    public int waypointsPassed = 0;
    public Transform nextWaypoint;

    public float speed = 30f; // will be set by factory at spawn
    public float reachThreshold = 1.0f; // Distance to switch to next waypoint

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        waypointsList = new CustomLinkedList();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        System.Array.Sort(waypoints, (a, b) => a.name.CompareTo(b.name));
        foreach (GameObject wp in waypoints)
        {
            waypointsList.Add(wp.transform);
        }

        currentNode = waypointsList.head;
        if (currentNode != null)
        {
            agent.SetDestination(currentNode.waypoint.position);
        }
    }

    void Update()
    {
        if (currentNode == null) return;

        if (!agent.pathPending && agent.remainingDistance <= reachThreshold)
        {
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        if (currentNode.next != null)
        {
            currentNode = currentNode.next;
        }
        else
        {
            currentNode = waypointsList.head; // loop to start
        }

        waypointsPassed++;
        nextWaypoint = currentNode.waypoint;
        agent.SetDestination(nextWaypoint.position);
    }

}
