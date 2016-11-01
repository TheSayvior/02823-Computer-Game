using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

	private GameObject player;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = player.transform.position + offset;
	}
}
