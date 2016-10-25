using UnityEngine;
using System.Collections;
using System;

public class RopeController : MonoBehaviour {

    public GameObject Player;

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
        if (_rope.isActiveAndEnabled == true)
        {
            _rope.enabled = false;
        }
        else if (_rope.isActiveAndEnabled == false)
        {
            _rope.enabled = true;
            //moveAnchor();
        }
    }

    private void moveAnchor()
    {
        throw new NotImplementedException();
    }
}
