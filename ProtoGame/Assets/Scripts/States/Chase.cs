using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    private int chaseTimer = 2;
    private int currTime = 0;
    private GridNode returnPosition;

    public Chase(GridNode _returnPos)
    {
        this.returnPosition = _returnPos;
    }

    public override GridNode executeMovement() 
    {
        foreach (Agent agent in BattleManager.getAgents)
        {
            if (agent is Player)
            {
                Vector2 adjustedPosition = new Vector2(Mathf.Floor(agent.transform.position.x), Mathf.Floor(agent.transform.position.y));
                GridNode targetNode = GridMap.getGridNode(adjustedPosition);
                Debug.Log(targetNode);
                return targetNode;
            }
        }
        return null;
    }

    public override Action executeAction() { return null; }

    public override State Update(Agent self)
    {
        currTime++;
        if (currTime < chaseTimer)
        {
            return this;
        }
        else
        {
            return new Wander(returnPosition);
        }
    }

    public override void onExit(Agent self) { }

    public override void onEnter(Agent self) { }
}
