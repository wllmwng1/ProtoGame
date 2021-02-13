using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Agent
{
    private List<GridNode> targetPath;
    private GridNode startNode, targetNode;
    private List<GridNode> walkCircle;
    private float movementSpeed = 0.01f;
    private float timeToReachTarget = 1.0f;
    private float t = 0.0f;
    private float walkDistance = 2.5f;


    override public void Movement()
    {
        if (targetNode != null)
        {
            t += Time.deltaTime / timeToReachTarget;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetNode.Position + new Vector2(0.5f, 0.5f), t);
            if (t - 0.5f < 0.1f)
            {
                GameObject grid = GameObject.Find("Grid");
                GridMap gridmap = grid.GetComponent<GridMap>();
                gridmap.resetCircle();
                Vector2 adjustedPosition = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
                walkCircle = GridMap.getGridNodesCircle(adjustedPosition, walkDistance);
                //Debug.Log(walkCircle.Length);
                gridmap.drawNodes(walkCircle);
            }
            if (t >= 1.0f)
            {
                if (targetPath.Count > 0)
                {
                    targetNode = targetPath[targetPath.Count - 1];
                    targetPath.RemoveAt(targetPath.Count - 1);
                }
                else
                {
                    targetNode = null;
                }
                t = 0.0f;
            }
        }
    }

    override public void Action()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject grid = GameObject.Find("Grid");
        GridMap gridmap = grid.GetComponent<GridMap>();
        Vector2 adjustedPosition = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
        walkCircle = GridMap.getGridNodesCircle(adjustedPosition, walkDistance);
        gridmap.drawNodes(walkCircle);
    }

    // Update is called once per frame
    void Update()
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
            //Debug.Log(targetNode.Position);
            //foreach (GridNode node in targetPath)
            //{
            //   Debug.Log(node.Position);
            //}
            //Debug.Log("End: " + end.Position);
            //gameObject.transform.position = adjustedPosition + new Vector2(0.5f,0.5f);
            
        }
        Movement();
    }
}
