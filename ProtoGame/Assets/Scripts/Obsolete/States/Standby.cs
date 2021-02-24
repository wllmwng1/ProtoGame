/*using System.Collections;
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
                return new Chase();
            }
        }
        return this;  
    }

    public override void onExit() { }

    public override void onEnter() { }
}
*/