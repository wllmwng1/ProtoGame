/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AStar
{
    public static List<GridNode> getPath(GridNode start, GridNode end)
    {
        GenericPriorityQueue<GridNode> openSet = new GenericPriorityQueue<GridNode>();
        List<GridNode> closedSet = new List<GridNode>();
        Dictionary<GridNode, GridNode> parentDic = new Dictionary<GridNode, GridNode>();
        Dictionary<GridNode, float> gScoreDic = new Dictionary<GridNode, float>();
        openSet.Insert(0, start);
        gScoreDic[start] = 0.0f;
        while (openSet.Queue.Length > 0)
        {
            GridNode curr = openSet.Pop();
            if (curr == end)
            {
                List<GridNode> result = new List<GridNode>();
                result.Add(end);
                while (curr != start)
                {
                    curr = parentDic[curr];
                    result.Add(curr);
                }
                return result;
            }
            closedSet.Add(curr);
            foreach (GridNode neighbour in curr.Neighbours)
            {
                if (closedSet.Contains(neighbour))
                {
                    continue;
                }
                float gScore = gScoreDic[curr] + 1.0f;
                if (!openSet.Contains(neighbour))
                {
                    openSet.Insert(gScore + Heuristic(neighbour, end), neighbour);
                    parentDic[neighbour] = curr;
                    gScoreDic[neighbour] = gScore;
                }
                else if (gScore < gScoreDic[neighbour])
                {
                    openSet.Update(neighbour, gScore + Heuristic(neighbour, end));
                    parentDic[neighbour] = curr;
                    gScoreDic[neighbour] = gScore;
                }
            }
        }
        Debug.Log("Path Not Found");
        Debug.Log(start.Position);
        Debug.Log(start.Neighbours.Length);
        Debug.Log(end.Position);
        return new List<GridNode>();
    }

    private static float Heuristic(GridNode x, GridNode y)
    {
        return Vector2.Distance(x.Position,y.Position);
    }
}
*/