using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GridMap testObject = gameObject.AddComponent<GridMap>();
        testObject.createDefinedMap(5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
