using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Test", 2);
	}

    void Test()
    {
        GetComponent<GridBase>().GenerateLevel();
    }
	
    // Update is called once per frame
    void Update () {
		
	}
}
