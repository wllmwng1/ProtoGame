using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementTrigger : Trigger
{
    private GridNode node;
    
    public MovementTrigger(BattleManager _manager, GridNode _node, Entity _origin, Timing _timing) : base(_manager,_origin,_timing)
    {
        this.node = _node;
    }

}
