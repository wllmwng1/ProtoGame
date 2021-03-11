using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standby : State
{
    private float distanceCheck = 5;

    public override GridNode executeMovement() { return null; }

    public override Action executeAction() { return null; }

    public override State Update(Agent self)
    {
        foreach (Agent agent in BattleManager.getAgents)
        {
            if (agent is Player & Vector2.Distance(agent.transform.position, self.transform.position) < distanceCheck)
            {
                Vector2 pos = new Vector2(self.transform.position.x, self.transform.position.y);
                return new Chase(GridMap.getGridNode(pos));
            }
        }
        return this;  
    }

    public override void onExit(Agent self) { }

    public override void onEnter(Agent self) { }
}
