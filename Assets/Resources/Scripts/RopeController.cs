using UnityEngine;
using System.Collections;
using System;

public class RopeController : MonoBehaviour {

    private GameObject Player;
    private PlayerShootingController ShootingController;

    HingeJoint2D _rope;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		ShootingController = Player.gameObject.GetComponentInChildren<PlayerShootingController> (); //GameObject.FindObjectOfType<PlayerShootingController> ();
        _rope = this.gameObject.GetComponent<HingeJoint2D>();
    }
	
	// Change so only causes bullet to fire and turns rope off after set time
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			FindRopeConnection ();
  
		}
	}

    private void FindRopeConnection()
    {
		//Allow shooting multiple ropes before one bullet makes a connection?
		//Adjust so shooting is disabled on bullet hit
        if (_rope.isActiveAndEnabled == true)
        {
            _rope.enabled = false;
        }
		//move this control to the bullet script
        else
        {
			ShootingController.publicShoot ();
        }
    }

    /*private void moveAnchor()
    {
        _rope.gameObject.transform.position = ShootingController.ropeHitPosition;
    }*/
}
