using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMap : MonoBehaviour
{
    //Represents the gridMap based system on which we will be working on.
    public TileBase tile;
    private static Dictionary<Vector2, GridNode> nodes = new Dictionary<Vector2, GridNode>();

    public static GridNode[] getGridNodes()
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

    //Creates a GridMap with nodes based on the tilemap given. Will fill whole tilemap.
    public void createDefinedMap(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int tilepos = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(tilepos))
            {
                nodes.Add(new Vector2(pos.x, pos.y), new GridNode(new Vector2(pos.x, pos.y)));
            }
        }
    }

    public void removeNodes(int x, int y)
    {
        Vector2 loc = new Vector2(x, y);
        List<GridNode> removed = new List<GridNode>();
        if (nodes.ContainsKey(new Vector2(x, y)))
        {
            removed.Add(nodes[loc]);
            nodes.Remove(loc);
        }
        this.removeNeighbours(removed);
    }

    public void removeNodes(int length, int width, int a, int b)
    {
        List<GridNode> removed = new List<GridNode>();
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (nodes.ContainsKey(new Vector2(x,y)))
                {
                    removed.Add(nodes[new Vector2(x + a, y + b)]);
                    nodes.Remove(new Vector2(x, y));
                }
            }
        }
        this.removeNeighbours(removed);
    }

    public void removeNodes(Tilemap tilemap)
    {
        List<GridNode> removed = new List<GridNode>();
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int tilepos = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(tilepos) && nodes.ContainsKey(new Vector2(pos.x, pos.y)))
            {
                removed.Add(nodes[new Vector2(pos.x,pos.y)]);
                nodes.Remove(new Vector2(pos.x,pos.y));
            }
        }
        this.removeNeighbours(removed);
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

    private void removeNeighbours(List<GridNode> nodes)
    {
        foreach (GridNode node in nodes)
        {
            foreach (GridNode neighbour in node.Neighbours)
            {
                neighbour.removeNeighbour(node);
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

    public void resetNodes()
    {
        GameObject gameObj = GameObject.Find("GridMap");
        Destroy(gameObj);
        nodes = new Dictionary<Vector2, GridNode>();
    }

    void Start()
    {
        GameObject map = GameObject.Find("Map");
        GameObject obstacle = GameObject.Find("Obstacle");
        Tilemap tilemap = map.GetComponent<Tilemap>();
        Tilemap obstaclemap = obstacle.GetComponent<Tilemap>();
        this.createDefinedMap(tilemap);
        removeNodes(obstaclemap);
        this.drawNodes();
        //resetNodes();
    }
}
