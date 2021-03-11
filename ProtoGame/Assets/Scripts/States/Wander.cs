using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : State
{
    private float distanceCheck = 5;
    private int patrolDistance = 3;
    private int stepCount = 3;
    private int index = 0;
    private GridNode returnPosition;

    private List<GridNode> patrolPath;

    public Wander(GridNode _returnPos)
    {
        returnPosition = _returnPos;
    }

    public override GridNode executeMovement() 
    {
        GridNode result = patrolPath[index];
        index++;
        return result;
    }

    public override Action executeAction() { return null; }

    public override State Update(Agent self)
    {
        foreach (Agent agent in BattleManager.getAgents)
        {
            if (agent is Player & Vector2.Distance(agent.transform.position, self.transform.position) < distanceCheck)
            {
                return new Chase(returnPosition);
            }
        }
        if (index >= patrolPath.Count)
        {
            return new Patrol();
        }
        return this;
    }

    public override void onExit(Agent self) { }

    public override void onEnter(Agent self) {
        patrolPath = new List<GridNode>();
        Vector2 adjustedPosition = new Vector2(Mathf.Floor(self.transform.position.x), Mathf.Floor(self.transform.position.y));
        GridNode position = GridMap.getGridNode(adjustedPosition);
        patrolPath.Add(position);
        List<GridNode> nodes = GridMap.getGridNodesCircle(position.Position, stepCount);
        for (int i = 0; i < patrolDistance - 1; i++)
        {
            position = nodes[Random.Range(0, nodes.Count - 1)];
            patrolPath.Add(position);
        }
        patrolPath.Add(returnPosition);
    }
}
