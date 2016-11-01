using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public float cameraOffsetHeight;

	private GameObject player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = new Vector3(0f, cameraOffsetHeight, -10f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.transform.position + offset;
	}
}
