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
        else if (_rope.isActiveAndEnabled == false && ShootingController.publicShoot())
        {
            moveAnchor();
            this.gameObject.transform.parent = ShootingController.hitGameObject.transform;
            _rope.enabled = true;
        }
    }

    private void moveAnchor()
    {
        _rope.gameObject.transform.position = ShootingController.ropeHitPosition;
    }
}
