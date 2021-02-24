/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
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
        return this;
    }

    public override void onExit() { }

    public override void onEnter() { }
}
*/