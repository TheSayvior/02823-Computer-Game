using UnityEngine;
using System.Collections;

public class playerAnimationScript : MonoBehaviour {
	public Animator playerAnimator;

	int runHash = Animator.StringToHash("startRunning");
	int jumpHash = Animator.StringToHash("jump");
	int landHash = Animator.StringToHash("land");
	int idleHash = Animator.StringToHash("idle");
	int isRunningHash = Animator.StringToHash("isRunning");

	// Use this for initialization
	void Start () {
		playerAnimator = GetComponent<Animator> ();
	}

	void animationTriggerJump(){
		playerAnimator.SetTrigger (jumpHash);
	}

	void animationTriggerLand(){
		playerAnimator.SetTrigger (landHash);
	}

	void animationTriggerRun(){
		playerAnimator.SetTrigger (runHash);
	}

	void animationTriggerIdle(){
		playerAnimator.SetTrigger (idleHash);
	}

	void AnimationSetIsRunningTrue(){
		playerAnimator.SetBool (isRunningHash, true);
	}

	void AnimationSetIsRunningFalse(){
		playerAnimator.SetBool (isRunningHash, false);
	}
}
