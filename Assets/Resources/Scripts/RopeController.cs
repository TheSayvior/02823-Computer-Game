using UnityEngine;
using System.Collections;
using System;

public class RopeController : MonoBehaviour {

    HingeJoint2D _rope;
	// Use this for initialization
	void Start () {
        _rope = this.gameObject.GetComponent<HingeJoint2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            FindRopeConnection();
        }


       // _rope.anchor
	}

    private void FindRopeConnection()
    {
        throw new NotImplementedException();
    }
}
