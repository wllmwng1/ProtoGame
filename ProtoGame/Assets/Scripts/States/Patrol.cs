using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    private float distanceCheck = 5;
    private int patrolDistance = 3;
    private int stepCount = 3;
    private int index = 0;

    private List<GridNode> patrolPath;

    public override GridNode executeMovement()
    {
        GridNode result = patrolPath[index];
        index++;
        if (index >= patrolPath.Count)
        {
            index = 0;
        }
        return result;
    }

    public override Action executeAction() { return null; }

    public override State Update(Agent self)
    {
        foreach (Agent agent in BattleManager.getAgents)
        {
            if (agent is Player & Vector2.Distance(agent.transform.position, self.transform.position) < distanceCheck)
            {
                return new Chase(patrolPath[0]);
            }
        }
        return this;
    }

    public override void onExit(Agent self) { }

    public override void onEnter(Agent self) 
    {
        patrolPath = new List<GridNode>();
        Vector2 adjustedPosition = new Vector2(Mathf.Floor(self.transform.position.x), Mathf.Floor(self.transform.position.y));
        GridNode position = GridMap.getGridNode(adjustedPosition);
        patrolPath.Add(position);
        for (int i = 0; i < patrolDistance; i++)
        {
            List<GridNode> nodes = GridMap.getGridNodesCircle(position.Position, stepCount);
            position = nodes[Random.Range(0, nodes.Count - 1)];
            patrolPath.Add(position);
        }
        
    }
}