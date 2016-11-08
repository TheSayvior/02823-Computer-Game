using UnityEngine;
using System.Collections;
using System;

public class RopeController : MonoBehaviour {

    private GameObject Player;
    private PlayerShootingController ShootingController;
	private Rigidbody2D playerRB;
	private PlayerMovementController playerMC;

    HingeJoint2D _rope;
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		playerRB = Player.GetComponent<Rigidbody2D> ();
		ShootingController = Player.gameObject.GetComponentInChildren<PlayerShootingController> (); //GameObject.FindObjectOfType<PlayerShootingController> ();
		playerMC = Player.GetComponent<PlayerMovementController>();
        _rope = this.gameObject.GetComponent<HingeJoint2D>();
    }

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			HandleRopeConnection ();
		}
	}
		

    private void HandleRopeConnection()  
    {
        if (_rope.isActiveAndEnabled == true)
        {
            _rope.enabled = false;

			StartCoroutine(playerMC.standup());
			playerRB.freezeRotation = true;		//stops player from rotating when not connected to rope
        }
        else
        {
			ShootingController.publicShoot ();
        }
    }

}
