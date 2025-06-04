using UnityEngine;
using UnityEngine.AI;

public class AdvancedAIRacer : MonoBehaviour
{
    private NavMeshAgent agent;
    private GraphNode currentNode;

    public WaypointGraph graph;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentNode = graph.GetStartNode();
        agent.SetDestination(currentNode.waypoint.position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, currentNode.waypoint.position) < 1.5f)
        {
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        currentNode = currentNode.GetRandomNeighbor();
        if (currentNode != null)
        {
            agent.SetDestination(currentNode.waypoint.position);
        }
    }
}
