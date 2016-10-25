using UnityEngine;
using System.Collections;

public class deployRope : MonoBehaviour {

	public GameObject rope;

	private bool isConnected;

	// Use this for initialization
	void Start () {
		rope.SetActive (false);
		isConnected = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)) {
			if (!isConnected) {
				rope.transform.position = Input.mousePosition;
				rope.SetActive (true);
				isConnected = true;
			} else {
				rope.SetActive (false);
				isConnected = false;
			}
		}
	}
}
