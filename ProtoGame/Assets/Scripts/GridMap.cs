using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    private Dictionary<Vector2, GridNode> nodes = new Dictionary<Vector2, GridNode>();

    public void createDefinedMap(int length, int width)
    {
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < width; y++)
            {
                nodes.Add(new Vector2(x,y), new GridNode(new Vector2(x,y)));
            }
        }

        foreach (KeyValuePair<Vector2,GridNode> kvp in nodes)
        {
            if (nodes.ContainsKey(kvp.Key + Vector2.right))
            {
                kvp.Value.addNeighbour(nodes[kvp.Key + Vector2.right]);
            }
            if (nodes.ContainsKey(kvp.Key + Vector2.left))
            {
                kvp.Value.addNeighbour(nodes[kvp.Key + Vector2.left]);
            }
            if (nodes.ContainsKey(kvp.Key + Vector2.up))
            {
                kvp.Value.addNeighbour(nodes[kvp.Key + Vector2.up]);
            }
            if (nodes.ContainsKey(kvp.Key + Vector2.down))
            {
                kvp.Value.addNeighbour(nodes[kvp.Key + Vector2.down]);
            }
        }
    }

    public GridNode[] getGridNodes()
    {
        List<GridNode> temp = new List<GridNode>();
        foreach (GridNode node in nodes.Values)
        {
            temp.Add(node);
        }
        return temp.ToArray();
    }
}
