using System.Collections.Generic;
using UnityEngine;

public class WaypointGraph : MonoBehaviour
{
    public List<GraphNode> nodes = new List<GraphNode>();

    public void AddNode(GraphNode node)
    {
        nodes.Add(node);
    }

    public GraphNode GetStartNode()
    {
        return nodes.Count > 0 ? nodes[0] : null;
    }
}
