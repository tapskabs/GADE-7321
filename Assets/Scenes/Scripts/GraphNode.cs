using System.Collections.Generic;
using UnityEngine;

public class GraphNode
{
    public Transform waypoint;
    public List<GraphNode> neighbours;

    public GraphNode(Transform waypoint)
    {
        this.waypoint = waypoint;
        this.neighbours = new List<GraphNode>();
    }
}
