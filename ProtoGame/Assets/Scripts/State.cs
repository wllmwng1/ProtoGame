using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract GridNode executeMovement();

    public abstract Action executeAction();

    public abstract State Update(Agent agent);

    public abstract void onEnter();

    public abstract void onExit();
}
