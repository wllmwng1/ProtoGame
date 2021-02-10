using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class ObstacleManager
{
    private static Dictionary<Vector2,Obstacle> obstacles = new Dictionary<Vector2, Obstacle>();

    public static Obstacle[] getObstacles()
    {
        List<Obstacle> temp = new List<Obstacle>();
        foreach (Obstacle obstacle in obstacles.Values)
        {
            temp.Add(obstacle);
        }
        return temp.ToArray();
    }

    public static Obstacle[] getObstacles(Vector2 location, float range)
    {
        List<Obstacle> temp = new List<Obstacle>();
        foreach (Obstacle obstacle in obstacles.Values)
        {
            if (Vector2.Distance(location,obstacle.Location) <= range)
            {
                temp.Add(obstacle);
            }
        }
        return temp.ToArray();
    }

    public static void addObstacle(Vector2 location)
    {
        obstacles.Add(location, new Obstacle(location));
    }

    public static void addObstacle(Vector2 location, bool coversVision)
    {
        obstacles.Add(location, new Obstacle(location, coversVision));
    }

    public static void addObstacles(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int tilepos = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(tilepos))
            {
                obstacles.Add(new Vector2(pos.x, pos.y), new Obstacle(new Vector2(pos.x, pos.y)));
            }
        }
    }

    public static void changeVision(Vector2 location, bool vision)
    {
        obstacles[location].changeVision(vision);
    }

    public static void removeObstacle(Vector2 location)
    {
        obstacles.Remove(location);
    }

    public static void reset()
    {
        obstacles.Clear();
    }
}

public class Obstacle
{
    private Vector2 location;
    private bool coversVision;

    public Vector2 Location { get { return location; } }
    public bool CoversVision { get { return coversVision; } }

    public Obstacle(Vector2 location, bool coversVision = true)
    {
        this.location = location;
        this.coversVision = coversVision;
    }

    public void changeVision(bool vision)
    {
        this.coversVision = vision;
    }
}
