using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    override public void Movement()
    {
        
    }

    override public void Action()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 adjustedPosition = new Vector2(Mathf.Floor(worldPosition.x)+0.5f, Mathf.Floor(worldPosition.y)+0.5f);
            gameObject.transform.position = adjustedPosition;
        }
    }
}
