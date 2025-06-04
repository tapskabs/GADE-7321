using System.Collections.Generic;
using UnityEngine;

public class GraphNode
{
    public Transform waypoint;
    public List<GraphNode> neighbors;

    public GraphNode(Transform waypoint)
    {
        this.waypoint = waypoint;
        neighbors = new List<GraphNode>();
    }

    public void AddNeighbor(GraphNode neighbor)
    {
        if (!neighbors.Contains(neighbor))
        {
            neighbors.Add(neighbor);
        }
    }

    public GraphNode GetRandomNeighbor()
    {
        if (neighbors.Count == 0) return null;
        return neighbors[Random.Range(0, neighbors.Count)];
    }
}
