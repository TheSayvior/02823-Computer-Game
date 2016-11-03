using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	public float cameraOffsetHeight;
	public float cameraScale;

	private GameObject player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		cameraScale = -15f;
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = new Vector3(0f, cameraOffsetHeight, cameraScale);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.transform.position + offset;
	}
}
