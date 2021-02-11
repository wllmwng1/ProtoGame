using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisionMap : MonoBehaviour
{
    public TileBase tile;

    public GridNode[] getVisionTiles(Vector2 location, float range)
    {
        List<GridNode> result = new List<GridNode>();
        GridNode[] nodes = gridNodeInRange(location, range);
        foreach (GridNode node in nodes)
        {
            RaycastHit2D hit = Physics2D.Raycast(location, (location - node.Position), Vector2.Distance(location, node.Position));
            if (hit.collider == null)
            {
                result.Add(node);
            }
        }
        return result.ToArray();
    }

    private GridNode[] gridNodeInRange(Vector2 location, float range)
    {
        List<GridNode> result = new List<GridNode>();
        foreach (GridNode node in GridMap.getGridNodes())
        {
            if (Vector2.Distance(node.Position, location) < range)
            {
                result.Add(node);
            }
        }
        return result.ToArray();
    }

    public void drawVision(Vector2 location, float range)
    {
        GameObject gameObj = new GameObject("Vision: " + gameObject.name);
        gameObj.AddComponent<TilemapRenderer>();
        var tilemap = gameObj.GetComponent<Tilemap>();
        gameObj.transform.SetParent(gameObject.transform);
        foreach (GridNode node in getVisionTiles(location, range))
        {
            tilemap.SetTile(new Vector3Int((int)node.Position.x, (int)node.Position.y, 0), tile);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
