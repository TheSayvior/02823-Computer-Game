﻿using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    public float moveSpeed;
    public float maxMoveSpeed;
    public float jumpPower;
    public int numJumps;
    public int hasJumped;
//    bool Swinging;

    Rigidbody2D _playerRB2D;

	playerAnimationScript _playAnim;

	public int standupTime;

	// Use this for initialization
	void Start () {
        _playerRB2D = this.gameObject.GetComponent<Rigidbody2D>();
		_playAnim = this.gameObject.GetComponent<playerAnimationScript> ();
//        Swinging = false;
        hasJumped = 0;
		standupTime = 1;
		_playerRB2D.freezeRotation = true;
		this.transform.position = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
		//handles animation
		if (_playerRB2D.velocity == Vector2.zero && !_playAnim.checkAnimation("PlayerJumpLand") && !_playAnim.checkAnimation("PlayerJumping"))
			_playAnim.animationTriggerIdle ();

		if (Input.GetKeyDown("w"))
		{
			// Do we want to limit y velocity? if they're moving up too fast they can't jump?
			//if (_playerRB2D.velocity.y < 5 && hasJumped != numJumps)
			if (hasJumped != numJumps)
			{
				_playerRB2D.velocity = new Vector2(_playerRB2D.velocity.x, 0f);
				_playerRB2D.velocity = _playerRB2D.velocity + new Vector2(0, jumpPower);
				hasJumped += 1;
				//Handles animation
				_playAnim.animationTriggerJump();
				_playAnim.animationSetBool ("Landed", false);
			}
		}
	}

    void FixedUpdate()
    {
//        if(Swinging == true)
//        {
//            return;
//        }

        if (Input.GetKey("a"))
        {
			this.transform.localEulerAngles = new Vector3 (0, 0, 0);
			if (_playerRB2D.velocity.x > -maxMoveSpeed){
                _playerRB2D.velocity = _playerRB2D.velocity + new Vector2(-moveSpeed, 0);
				//handles animation
				if (_playerRB2D.velocity.y == 0) {
					_playAnim.animationTriggerRun();
				}
			}
        }

        if (Input.GetKey("d"))
        {
			this.transform.localEulerAngles = new Vector3 (0, 180, 0);
			if (_playerRB2D.velocity.x < maxMoveSpeed) {
				_playerRB2D.velocity = _playerRB2D.velocity + new Vector2 (moveSpeed, 0);
				//handles animation
				if (_playerRB2D.velocity.y == 0) {
					_playAnim.animationTriggerRun();
				}
			}
        }

        // Maybe add force, or figure out a way to get it more jumpy
        
    }

	void OnTriggerEnter2D(Collider2D touched){
		if (touched.tag == "Block") {
			hasJumped = 0;
			//handles animation
			_playAnim.animationSetBool("Landed", true);
		}
	}

	public IEnumerator standup(){
		float elapsedTime = 0.0f;
		Quaternion targetRotation = Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y, 0.0f);
		while (elapsedTime < standupTime) {
			this.transform.rotation = Quaternion.Lerp (this.transform.rotation, targetRotation, elapsedTime/standupTime);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		yield return null;
	}
		
}
