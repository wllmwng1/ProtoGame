using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static List<Agent> agents = new List<Agent>();

    public static void addAgent(Agent agent)
    {
        agents.Add(agent);
    }

    public static void addAgents(List<Agent> newAgents)
    {
        foreach (Agent agent in newAgents)
        {
            agents.Add(agent);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Agent currAgent = agents[0];
        Agent.Phase currPhase = currAgent.currPhase;
        bool finishedPhase = false;
        switch(currAgent.currPhase)
        {
            case Agent.Phase.Decision:
                finishedPhase = currAgent.Decision();
                break;
            case Agent.Phase.Movement:
                finishedPhase = currAgent.Movement();
                break;
        }
        if (finishedPhase & currPhase == Agent.Phase.Movement)
        {
            agents.Remove(currAgent);
            agents.Add(currAgent);
            Debug.Log("Next Agent");
        }
    }
}
