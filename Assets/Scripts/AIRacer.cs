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

        // Sort waypoints alphabetically by name to keep order
        System.Array.Sort(waypoints, (a, b) => a.name.CompareTo(b.name));
        foreach (GameObject wp in waypoints)
        {
            waypointsList.Add(wp.transform);
        }

        currentNode = waypointsList.head;
        agent.SetDestination(currentNode.waypoint.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint") && other.transform == currentNode.waypoint)
        {
            currentNode = currentNode.next;
            agent.SetDestination(currentNode.waypoint.position);
        }
    }
}
