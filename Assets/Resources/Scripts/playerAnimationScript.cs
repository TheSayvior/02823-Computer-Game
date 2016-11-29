using UnityEngine;
using System.Collections;

public class playerAnimationScript : MonoBehaviour {
	public Animator playerAnimator;
	public Animator fireAnimator;

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
		fireAnimator.Play("fireJump");
	}

	public void animationSetBool(string name, bool value){
		playerAnimator.SetBool (name, value);
		fireAnimator.SetBool (name, value);
	}

	public void animationTriggerRun(){
		if((!(checkAnimation("PlayerRun") || checkAnimation("PlayerStartRunning"))) && !playerAnimator.GetBool("isRopeConnected")){
			playerAnimator.Play ("PlayerStartRunning");
			fireAnimator.Play ("fireStartRunning");
		}
	}

	public void animationTriggerIdle(){
		playerAnimator.Play ("PlayerIdle");
		fireAnimator.Play ("fireIdle");
	}

	public void AnimationSetIsRunningTrue(){
		playerAnimator.SetBool (isRunningHash, true);
		fireAnimator.SetBool (isRunningHash, true);
	}

	public void AnimationSetIsRunningFalse(){
		playerAnimator.SetBool (isRunningHash, false);
		fireAnimator.SetBool (isRunningHash, false);
	}
}
