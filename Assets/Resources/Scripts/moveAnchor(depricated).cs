using UnityEngine;
using System.Collections;

public class moveAnchor : MonoBehaviour {

	bool isRoped;
	SpringJoint2D hinge;

	public Vector3 clickPosition;

	// Use this for initialization
	void Start () {
		hinge = this.GetComponent<SpringJoint2D> ();
		hinge.enabled = false;
		isRoped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			if (isRoped == false) {
				clickPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition); //ignore in true
				this.transform.position = clickPosition;
				hinge.enabled = true;
				isRoped = true;
			} else if (isRoped == true) {
				hinge.enabled = false;
				isRoped = false;
			}
		}
	}
}
