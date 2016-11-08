using UnityEngine;
using System.Collections;

public class bulletAnchorSet : MonoBehaviour {

	Rigidbody2D playerRB; //to freeze rotation when activating rope
	Rigidbody2D bulletRB;
	HingeJoint2D rope;

	// Use this for initialization
	void Start () {
		bulletRB = this.GetComponent<Rigidbody2D> ();
		playerRB = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
		rope = GameObject.FindGameObjectWithTag ("Rope").GetComponent<HingeJoint2D> ();
	}

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.gameObject.tag == "Block" || hit.gameObject.tag == "ropeable") {
			rope.gameObject.transform.position = bulletRB.position;
			rope.enabled = true;
			playerRB.freezeRotation = false; //want to be able to rotate when swinging around
			this.gameObject.active = false;
			print("hit");
		}
	}
}