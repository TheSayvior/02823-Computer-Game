using UnityEngine;
using System.Collections;

public class playerAnimationScript : MonoBehaviour {
	public Animator playerAnimator;

//	int runHash = Animator.StringToHash("startRunning");
//	int jumpHash = Animator.StringToHash("jump");
//	int landHash = Animator.StringToHash("land");
//	int idleHash = Animator.StringToHash("idle");
	int isRunningHash = Animator.StringToHash ("isRunning");

	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator> ();
	}

	public bool checkAnimation(string name){
		return playerAnimator.GetCurrentAnimatorStateInfo (0).IsName (name);
	}

	public void animationTriggerJump(){
		playerAnimator.Play ("PlayerJump");
	}

	public void animationSetBool(string name, bool value){
		playerAnimator.SetBool (name, value);
	}

	public void animationTriggerRun(){
		if(!(checkAnimation("PlayerRun") || checkAnimation("PlayerStartRunning")))
			playerAnimator.Play ("PlayerStartRunning");
	}

	public void animationTriggerIdle(){
		playerAnimator.Play ("PlayerIdle");
	}

	public void AnimationSetIsRunningTrue(){
		playerAnimator.SetBool (isRunningHash, true);
	}

	public void AnimationSetIsRunningFalse(){
		playerAnimator.SetBool (isRunningHash, false);
	}
}
