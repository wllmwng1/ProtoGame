/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    private float t = 0.0f;
    private float timeToSpaceOut = 1.0f;
    private float timeToReachTarget = 1.0f;
    private GridNode startNode, targetNode;
    private List<GridNode> targetPath;
    private Action targetAction;
    private State currState;

    override public bool Decision()
    {
        t += Time.deltaTime / timeToSpaceOut;
        if (t > 1.0f)
        {
            targetNode = currState.executeMovement();
            Vector2 startPos = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
            startNode = GridMap.getGridNode(startPos);
            if (targetNode != null)
            {
                targetPath = AStar.getPath(startNode, targetNode);
                targetNode = targetPath[targetPath.Count - 1];
                targetPath.RemoveAt(targetPath.Count - 1);
            }
            targetAction = currState.executeAction();
            State nextState = currState.Update(this);
            if (nextState != currState)
            {
                currState.onExit();
                nextState.onEnter();
                currState = nextState;
            }
            currPhase = Phase.Movement;
            t = 0.0f;
            return true;
        }
        return false;
    }

    override public bool Movement()
    {
        bool result = true;
        if (targetNode != null)
        {
            result = false;
            GameObject grid = GameObject.Find("Grid");
            GridMap gridmap = grid.GetComponent<GridMap>();
            t += Time.deltaTime / timeToReachTarget;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetNode.Position + new Vector2(0.5f, 0.5f), t);
            if (t - 0.5f < 0.1f)
            {
                //gridmap.resetCircle();
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
        currPhase = Phase.Decision;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {

        currPhase = Phase.Decision;
        BattleManager.addAgent(this);
        Vector2 adjustedPosition = new Vector2(Mathf.Floor(gameObject.transform.position.x), Mathf.Floor(gameObject.transform.position.y));
        GridNode position = GridMap.getGridNode(adjustedPosition);
        position.placeAgent(this);
        currState = new Standby();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
*/