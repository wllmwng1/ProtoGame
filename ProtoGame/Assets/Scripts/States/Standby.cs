using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standby : State
{
    public override GridNode executeMovement() { return null; }

    public override Action executeAction() { return null; }

    public override State Update() { return this;  }

    public override void onExit() { }

    public override void onEnter() { }
}
