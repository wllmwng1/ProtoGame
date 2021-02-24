using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
[System.Obsolete("Created new GridNode")]

public class oldGridNode
{
    //Represents a single node on the grid and its neighbours.

    private Vector2 position;
    private List<GridNode> neighbours;
    private Agent agent;

    public Vector2 Position { get { return this.position; } }
    public GridNode[] Neighbours { get { return this.neighbours.ToArray(); } }
    public Agent Agent { get { return this.agent; } }

    public GridNode(Vector2 _position)
    {
        position = _position;
        neighbours = new List<GridNode>();
        agent = null;
    }

    public void addNeighbour(GridNode neighbour)
    {
        if (!neighbours.Contains(neighbour))
        {
            neighbours.Add(neighbour);
        }
    }

    public void removeNeighbour(GridNode neighbour)
    {
        if (neighbours.Contains(neighbour))
        {
            neighbours.Remove(neighbour);
        }
    }

    public void placeAgent(Agent agent)
    {
        this.agent = agent;
    }

    public void removeAgent()
    {
        this.agent = null;
    }
}
*/