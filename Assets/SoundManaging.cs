using UnityEngine;
using System.Collections;

public class SoundManaging : MonoBehaviour {

    GameObject _player;

    AudioSource Flame;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");

        this.transform.parent = _player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
