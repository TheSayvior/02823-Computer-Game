﻿using UnityEngine;
using System.Collections;
using System;

public class RopeController : MonoBehaviour {

    public GameObject Player;
    public PlayerShootingScript Gun;

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
            moveAnchor(Gun.publicShoot());
            _rope.enabled = true;
            //moveAnchor();
        }
    }

    private void moveAnchor( Vector2 position)
    {
        _rope.gameObject.transform.position = position;
    }
}
