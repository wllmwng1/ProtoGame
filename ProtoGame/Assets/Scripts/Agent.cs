using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Agent : MonoBehaviour
{
    public enum Phase { Decision, Action, Movement };

    private Phase phase;

    public abstract bool Movement();

    public abstract void Action();

    public abstract bool Decision();

    public virtual Phase currPhase { get { return this.phase; } set { phase = value; } }
}
