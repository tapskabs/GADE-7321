using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LinkedList;
using UnityEngine.AI;

public class AIRacer : MonoBehaviour
{
    private NavMeshAgent agent;
    private CustomLinkedList waypointsList;
    private Node currentNode;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypointsList = new CustomLinkedList();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");

        // Sort waypoints to maintain order
        System.Array.Sort(waypoints, (a, b) => a.name.CompareTo(b.name));
        foreach (GameObject wp in waypoints)
        {
            waypointsList.Add(wp.transform);
        }

        currentNode = waypointsList.head;
        agent.SetDestination(currentNode.waypoint.position);
    }

    void Update()
    {
        // Just in case trigger misses, add a backup check by distance
        if (Vector3.Distance(transform.position, currentNode.waypoint.position) < 1.0f)
        {
            GoToNextWaypoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint") && other.transform == currentNode.waypoint)
        {
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        currentNode = currentNode.next;
        agent.SetDestination(currentNode.waypoint.position);
    }
}
