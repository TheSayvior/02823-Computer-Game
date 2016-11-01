using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    public int speed;
    public int jumpPower;
    public int maxSpeed;
    public int numJumps;
    public int hasJumped;
    bool Swinging;

    Rigidbody2D _playerRB2D;

	// Use this for initialization
	void Start () {
        _playerRB2D = this.gameObject.GetComponent<Rigidbody2D>();
        Swinging = false;
        hasJumped = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    // Check childcapsule collider. If trigger, then reset hasJumped to 0
	}

    void FixedUpdate()
    {
        if(Swinging == true)
        {
            return;
        }

        if (Input.GetKey("a"))
        {
            if (_playerRB2D.velocity.x > -maxSpeed)
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(-speed, 0);
        }

        if (Input.GetKey("d"))
        {
            if (_playerRB2D.velocity.x < maxSpeed)
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(speed, 0);
        }

        // Maybe add force, or figure out a way to get it more jumpy
        if (Input.GetKey("w"))
        {
            // Do we want to limit y velocity? if they're moving up too fast they can't jump?
            if (_playerRB2D.velocity.y < 5 && hasJumped != numJumps)
            {
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(0, jumpPower);
                hasJumped += 1;
            }
        }
    }

	void OnTriggerEnter2D(Collider2D touched){
		if (touched.tag == "Block") {
			hasJumped = 0;
		}
	}
}
