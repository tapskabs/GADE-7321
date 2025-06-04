using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedAIRacer : MonoBehaviour
{
    public float speed = 30f;
    private NavMeshAgent agent;
    private GraphNode currentNode;

    private WaypointGraph waypointGraph;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        waypointGraph = FindObjectOfType<WaypointGraph>();
        waypointGraph.BuildGraph(); // Make sure this runs once per race setup

        currentNode = waypointGraph.GetStartingNode();
        if (currentNode != null)
        {
            agent.SetDestination(currentNode.waypoint.position);
        }
    }

    void Update()
    {
        if (currentNode == null || currentNode.waypoint == null) return;

        if (Vector3.Distance(transform.position, currentNode.waypoint.position) < 1.5f)
        {
            GoToNextNode();
        }
    }

    void GoToNextNode()
    {
        if (currentNode.neighbors.Count > 0)
        {
            int index = Random.Range(0, currentNode.neighbors.Count);
            currentNode = currentNode.neighbors[index];
            agent.SetDestination(currentNode.waypoint.position);
        }
    }
}
