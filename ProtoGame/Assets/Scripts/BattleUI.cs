using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    private Agent currAgent;
    private Text currText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObj = GameObject.Find("CurrAgentText");
        currText = gameObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCurrAgent(Agent nextAgent)
    {
        if (nextAgent != currAgent)
        {
            currText.text = "Current Agent: " + nextAgent;
        }
    }
}
