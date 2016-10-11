using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    bool Swinging;

    Rigidbody2D _playerRB2D;

	// Use this for initialization
	void Start () {
        _playerRB2D = this.gameObject.GetComponent<Rigidbody2D>();
        Swinging = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if(Swinging == true)
        {
            return;
        }

        if (Input.GetKey("a"))
        {
            if (_playerRB2D.velocity.x > -5)
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(-1, 0);
        }

        if (Input.GetKey("d"))
        {
            if (_playerRB2D.velocity.x < 5)
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(1, 0);
        }

        if (Input.GetKey("w"))
        {
            if (_playerRB2D.velocity.y < 5)
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(0, 1);
        }
    }
}
