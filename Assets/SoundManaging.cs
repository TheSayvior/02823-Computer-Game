using UnityEngine;
using System.Collections;

public class SoundManaging : MonoBehaviour {

    GameObject _player;
    Rigidbody2D _playerRP;

    public AudioSource StandardFlame;
    public AudioSource WindyFlame;

    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerRP = _player.GetComponent<Rigidbody2D>();
        this.transform.parent = _player.transform;
	}

    void Update()
    {
        WindyFlameUpdate();
    }

    void WindyFlameUpdate()
    {
        if(_playerRP.velocity.magnitude > 2)
        {
            WindyFlame.volume = Mathf.Clamp((_playerRP.velocity.magnitude -2)*0.1f,0 , 0.6f); 
        } else
        {
            WindyFlame.volume = 0;
        }
    }

    public void FlameSoundUpdate(float volume)
    {
        StandardFlame.volume = volume;
    }
}
