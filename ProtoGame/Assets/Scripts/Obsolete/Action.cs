using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action
{
    public abstract void execute();

    public abstract void onEnter();

    public abstract void onExit();
}
