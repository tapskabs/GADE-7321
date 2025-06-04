using System.Collections.Generic;
using UnityEngine;

public class GraphNode
{
    public Transform waypoint;
    public List<GraphNode> neighbors;

    public GraphNode(Transform waypoint)
    {
        this.waypoint = waypoint;
        this.neighbors = new List<GraphNode>();
    }
}
