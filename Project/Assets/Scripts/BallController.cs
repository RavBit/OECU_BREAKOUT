using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    private bool ballInField;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            transform.parent = null;
            ballInField = true;
            rb.isKinematic = false;
            rb.AddForce(2000, 2000, 0);
        }
    }
}
