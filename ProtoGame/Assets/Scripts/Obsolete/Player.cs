/*using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Agent
{
    private List<GridNode> targetPath;
    private GridNode startNode, targetNode;
    private List<GridNode> walkCircle;
    //private float movementSpeed = 0.01f;
    private float timeToReachTarget = 1.0f;
    private float t = 0.0f;
    private float walkDistance = 2.5f;

    //public int getPhase { get { return (int)this.phase; } }

    override public bool Movement()
    {
        bool result = true;
        //Debug.Log(targetNode);
        if (targetNode != null)
        {
            result = false;
            GameObject grid = GameObject.Find("Grid");
            GridMap gridmap = grid.GetComponent<GridMap>();
            t += Time.deltaTime / timeToReachTarget;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetNode.Position + new Vector2(0.5f, 0.5f), t);
            if (t - 0.5f < 0.1f)
            {
                gridmap.resetCircle();
                Vector2 adjustedPosition = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
            }
            if (t >= 1.0f)
            {
                startNode.removeAgent();
                startNode = targetNode;
                startNode.placeAgent(this);
                if (targetPath.Count > 0)
                {
                    targetNode = targetPath[targetPath.Count - 1];
                    targetPath.RemoveAt(targetPath.Count - 1);
                }
                else
                {
                    walkCircle = GridMap.getGridNodesCircle(targetNode.Position, walkDistance);
                    gridmap.drawNodes(walkCircle);
                    targetNode = null;
                    currPhase = Phase.Action;
                    result = true;
                }
                Vector2 adjustedPosition = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
                t = 0.0f;
            }
        }
        else
        {
            currPhase = Phase.Action;
        }
        return result;
    }

    override public bool Action()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Action");
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 adjustedPosition = new Vector2(Mathf.Floor(worldPosition.x), Mathf.Floor(worldPosition.y));
            Vector2 startPos = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
            GridNode start = GridMap.getGridNode(startPos);
            GridNode end = GridMap.getGridNode(adjustedPosition);
            if (end != null)
            {
                if (start.Neighbours.Contains(end) & end.Agent != null)
                {
                    Debug.Log("Agent attacked another agent");
                }
                else
                {
                    Debug.Log("No Action");
                }
            }
            else
            {
                Debug.Log("No Action");
            }
            currPhase = Phase.Decision;
            return true;
            //Debug.Log(targetNode.Position);
            //foreach (GridNode node in targetPath)
            //{
            //   Debug.Log(node.Position);
            //}
            //Debug.Log("End: " + end.Position);
            //gameObject.transform.position = adjustedPosition + new Vector2(0.5f,0.5f);
        }
        return false;
    }

    override public bool Decision()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 adjustedPosition = new Vector2(Mathf.Floor(worldPosition.x), Mathf.Floor(worldPosition.y));
            Vector2 startPos = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
            GridNode start = GridMap.getGridNode(startPos);
            GridNode end = GridMap.getGridNode(adjustedPosition);
            walkCircle = GridMap.getGridNodesCircle(startPos, walkDistance);
            if (walkCircle.Contains(end))
            {
                targetPath = AStar.getPath(start, end);
                //gameObject.transform.position = adjustedPosition;
                startNode = start;
                targetNode = targetPath[targetPath.Count - 1];
                targetPath.RemoveAt(targetPath.Count - 1);
            }
            else
            {
                targetNode = null;
            }
            currPhase = Phase.Movement;
            return true;
            //Debug.Log(targetNode.Position);
            //foreach (GridNode node in targetPath)
            //{
            //   Debug.Log(node.Position);
            //}
            //Debug.Log("End: " + end.Position);
            //gameObject.transform.position = adjustedPosition + new Vector2(0.5f,0.5f);
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject grid = GameObject.Find("Grid");
        GridMap gridmap = grid.GetComponent<GridMap>();
        Vector2 adjustedPosition = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
        GridNode position = GridMap.getGridNode(adjustedPosition);
        position.placeAgent(this);
        walkCircle = GridMap.getGridNodesCircle(adjustedPosition, walkDistance);
        gridmap.drawNodes(walkCircle);
        currPhase = Phase.Decision;
        BattleManager.addAgent(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/