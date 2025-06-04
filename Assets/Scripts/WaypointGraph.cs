using System.Collections.Generic;
using UnityEngine;

public class WaypointGraph : MonoBehaviour
{
    public Transform[] waypointObjects; // Assign these in the Inspector in order: A, B, C...
    public List<GraphNode> nodes = new List<GraphNode>();
    private Dictionary<Transform, GraphNode> nodeLookup = new Dictionary<Transform, GraphNode>();

    public void BuildGraph()
    {
        nodes.Clear();
        nodeLookup.Clear();

        // Create nodes
        foreach (Transform wp in waypointObjects)
        {
            GraphNode node = new GraphNode(wp);
            nodes.Add(node);
            nodeLookup[wp] = node;
        }

        // Example connections (you should edit according to your track structure):
        AddEdge(waypointObjects[0], waypointObjects[1]); // A -> B
        AddEdge(waypointObjects[1], waypointObjects[2]); // B -> C
        AddEdge(waypointObjects[1], waypointObjects[3]); // B -> D (branch)
        AddEdge(waypointObjects[2], waypointObjects[4]); // C -> E
        AddEdge(waypointObjects[3], waypointObjects[4]); // D -> E
        // Add more edges as needed...

        // Last node loops to A
        AddEdge(waypointObjects[waypointObjects.Length - 1], waypointObjects[0]); // J -> A
    }

    public void AddEdge(Transform from, Transform to)
    {
        if (nodeLookup.ContainsKey(from) && nodeLookup.ContainsKey(to))
        {
            nodeLookup[from].neighbors.Add(nodeLookup[to]);
        }
    }

    public GraphNode GetStartingNode()
    {
        return nodes.Count > 0 ? nodes[0] : null;
    }
}
