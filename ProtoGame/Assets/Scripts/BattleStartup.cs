using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BattleStartup : MonoBehaviour
{
    public GameObject prefab;
    public TileBase tile;
    void Awake()
    {
        GameObject clone = Instantiate(prefab, gameObject.transform.parent);
        GridView view = clone.AddComponent<GridView>();
        GameObject map = GameObject.Find("Map");
        GameObject obstacle = GameObject.Find("Obstacle");
        Tilemap tilemap = map.GetComponent<Tilemap>();
        Tilemap obstaclemap = obstacle.GetComponent<Tilemap>();
        GridMap gridmap = new GridMapBuilder().addTilemap(tilemap).removeTilemap(obstaclemap).create();
        view.Instantiate(gridmap, tile);
        view.toggleNodes();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
