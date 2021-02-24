/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Agent
{
    private float t = 0.0f;
    private float timeToSpaceOut = 1.0f;

    override public bool Decision()
    {
        t += Time.deltaTime / timeToSpaceOut;
        if (t > 1.0f)
        {
            currPhase = Phase.Movement;
            t = 0.0f;
            return true;
        }
        return false;
    }

    override public bool Movement()
    {
        currPhase = Phase.Decision;
        return true;
    }

    override public bool Action()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/