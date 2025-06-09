using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(AdvancedRacerTracker))]
public class AdvancedAIRacer : MonoBehaviour
{
    public float speed = 30f;

    private NavMeshAgent agent;
    private WaypointGraph waypointGraph;
    private AdvancedRacerTracker tracker;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.25f); // Allow SFXManager to initialize

        SFXManager.Instance.PlaySFX("startRace");

        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        tracker = GetComponent<AdvancedRacerTracker>();
        waypointGraph = FindObjectOfType<WaypointGraph>();
        waypointGraph.BuildGraph(); // Ensure it's only called once in a GameManager setup

        tracker.currentNode = waypointGraph.GetStartingNode();

        if (tracker.currentNode != null && tracker.currentNode.neighbours.Count > 0)
        {
            tracker.nextNode = tracker.currentNode.neighbours[Random.Range(0, tracker.currentNode.neighbours.Count)];
            agent.SetDestination(tracker.nextNode.waypoint.position);
        }
    }

    void Update()
    {
        if (tracker.nextNode == null || tracker.nextNode.waypoint == null)
            return;
        SFXManager.Instance.PlaySFX("startRace");
        // Check if we've reached the next node
        if (Vector3.Distance(transform.position, tracker.nextNode.waypoint.position) < 1.5f)
        {
            tracker.PassWaypoint(tracker.nextNode);

            if (tracker.nextNode.neighbours.Count > 0)
            {
                agent.SetDestination(tracker.nextNode.waypoint.position);
            }
        }
    }
}
