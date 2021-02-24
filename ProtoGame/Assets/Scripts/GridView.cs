using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridView : MonoBehaviour, Observer
{
    private Tilemap tilemap;
    public TileBase tile;
    private GridMap map;
    private Vector2[] locations;
    private bool drawMap;

    public void Instantiate(GridMap _map, TileBase _tile)
    {
        _map.subscribe(this);
        map = _map;
        tile = _tile;
        drawMap = false;
        GameObject gameObj = new GameObject("GridMap");
        gameObj.AddComponent<TilemapRenderer>();
        tilemap = gameObj.GetComponent<Tilemap>();
        gameObj.transform.SetParent(gameObject.transform);
    }

    public void drawNodes()
    {
        foreach (Vector2 loc in locations)
        {
            tilemap.SetTile(new Vector3Int((int)loc.x, (int)loc.y, 0), tile);
        }
    }

    public void removeNodes()
    {
        foreach (Vector2 loc in locations)
        {
            tilemap.SetTile(new Vector3Int((int)loc.x, (int)loc.y, 0), null);
        }
    }

    public void toggleNodes()
    {
        if (drawMap)
        {
            drawNodes();
            drawMap = false;
        }
        else
        {
            removeNodes();
            drawMap = true;
        }
    }

    public void observerUpdate()
    {
        this.removeNodes();
        locations = map.getGridNodes;
        if (drawMap)
        {
            this.drawNodes();
        }
    }
}
