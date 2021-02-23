using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static List<Agent> agents = new List<Agent>();

    public static Agent[] getAgents { get { return agents.ToArray(); } }

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
        bool finishedPhase = false;
        switch(currAgent.currPhase)
        {
            case Agent.Phase.Decision:
                finishedPhase = currAgent.Decision();
                break;
            case Agent.Phase.Movement:
                finishedPhase = currAgent.Movement();
                break;
            case Agent.Phase.Action:
                finishedPhase = currAgent.Action();
                break;
        }
        if (finishedPhase)
        {
            Debug.Log(currAgent.currPhase);
            Agent.Phase currPhase = currAgent.currPhase;
            if (currPhase == Agent.Phase.Decision)
            {
                agents.Remove(currAgent);
                agents.Add(currAgent);
                Debug.Log("Next Agent" + currAgent);
                GameObject gameObj = GameObject.Find("UI");
                BattleUI ui = gameObj.GetComponent<BattleUI>();
                ui.changeCurrAgent(agents[0]);
            }
        }
    }
}
