﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode
{
    private Vector2 position;
    private List<GridNode> neighbours;

    public Vector2 Position { get { return this.position; } }
    public GridNode[] Neighbours { get { return this.neighbours.ToArray(); } }

    public GridNode(Vector2 _position)
    {
        position = _position;
        neighbours = new List<GridNode>();
    }
    public void addNeighbour(GridNode neighbour)
    {
        if (!neighbours.Contains(neighbour))
        {
            neighbours.Add(neighbour);
        }
    }
}