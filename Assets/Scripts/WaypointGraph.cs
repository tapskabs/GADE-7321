using System.Collections.Generic;
using UnityEngine;

public class WaypointGraph : MonoBehaviour
{
    public Transform[] waypointObjects; 
    public List<GraphNode> nodes = new List<GraphNode>();
    private Dictionary<Transform, GraphNode> nodeLookup = new Dictionary<Transform, GraphNode>();

    public void BuildGraph()
    {
        nodes.Clear();
        nodeLookup.Clear();

        // Created nodes
        foreach (Transform wp in waypointObjects)
        {
            GraphNode node = new GraphNode(wp);
            nodes.Add(node);
            nodeLookup[wp] = node;
        }

        // Track structure:
        AddEdge(waypointObjects[0], waypointObjects[1]); // A -> B
        AddEdge(waypointObjects[1], waypointObjects[2]); // B -> C
        AddEdge(waypointObjects[1], waypointObjects[3]); // B -> D (branch)
        AddEdge(waypointObjects[2], waypointObjects[4]); // C -> E
        AddEdge(waypointObjects[3], waypointObjects[4]); // D -> E
        AddEdge(waypointObjects[4], waypointObjects[5]);
        AddEdge(waypointObjects[5], waypointObjects[6]);
        AddEdge(waypointObjects[6], waypointObjects[7]);
        AddEdge(waypointObjects[7], waypointObjects[8]);
        AddEdge(waypointObjects[8], waypointObjects[9]);
        AddEdge(waypointObjects[9], waypointObjects[10]);
        AddEdge(waypointObjects[9], waypointObjects[11]);
        AddEdge(waypointObjects[10], waypointObjects[12]);
        AddEdge(waypointObjects[11], waypointObjects[12]);
        // Add more edges as needed...

        // Last node loops to A
        AddEdge(waypointObjects[waypointObjects.Length - 1], waypointObjects[0]); // J -> A
    }

    public void AddEdge(Transform from, Transform to)
    {
        if (nodeLookup.ContainsKey(from) && nodeLookup.ContainsKey(to))
        {
            nodeLookup[from].neighbours.Add(nodeLookup[to]);
        }
    }

    public GraphNode GetStartingNode()
    {
        return nodes.Count > 0 ? nodes[0] : null;
    }
}
