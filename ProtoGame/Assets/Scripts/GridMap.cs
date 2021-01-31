using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour
{
    //Represents the gridMap based system on which we will be working on.
    public TileBase tile;
    private Dictionary<Vector2, GridNode> nodes = new Dictionary<Vector2, GridNode>();

    public GridNode[] getGridNodes()
    {
        List<GridNode> temp = new List<GridNode>();
        foreach (GridNode node in nodes.Values)
        {
            temp.Add(node);
        }
        return temp.ToArray();
    }

    //Creates a rectangular GridMap with nodes based on length and width provided
    public void createDefinedMap(int length, int width)
    {
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < width; y++)
            {
                nodes.Add(new Vector2(x,y), new GridNode(new Vector2(x,y)));
            }
        }

        this.assignNeighbours(nodes);
    }

    //Assigns neighbours to the nodes.
    private void assignNeighbours(Dictionary<Vector2,GridNode> nodes)
    {
        foreach (KeyValuePair<Vector2, GridNode> kvp in nodes)
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

    //Draws the gridMap onto the scene using the provided TileBase tile.
    public void drawNodes()
    {
        GameObject gameObj = new GameObject("GridMap");
        gameObj.AddComponent<TilemapRenderer>();
        var tilemap = gameObj.GetComponent<Tilemap>();
        gameObj.transform.SetParent(gameObject.transform);
        foreach (GridNode node in nodes.Values)
        {
            tilemap.SetTile(new Vector3Int((int)node.Position.x,(int)node.Position.y,0),tile);
        }
    }

    void Start()
    {
        this.createDefinedMap(2, 5);
        this.drawNodes();
    }
}
