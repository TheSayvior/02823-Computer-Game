using UnityEngine;
using System.Collections;

public class fireAnimationScript : MonoBehaviour {
	public Animator fireAnimator;

	int isRunningHash = Animator.StringToHash ("isRunning");

	// Use this for initialization
	void Start () {
		fireAnimator = GetComponent<Animator> ();
	}

	void Update(){
		if (Input.GetKeyDown ("w")) {
			animationTriggerJump ();
		}
	}

	public bool checkAnimation(string name){
		return fireAnimator.GetCurrentAnimatorStateInfo (0).IsName (name);
	}

	public void animationTriggerJump(){
		fireAnimator.Play ("fireJump");
	}

//	public void animationSetBool(string name, bool value){
//		fireAnimator.SetBool (name, value);
//	}
//
//	public void animationTriggerRun(){
//		if(!(checkAnimation("PlayerRun") || checkAnimation("PlayerStartRunning")))
//			fireAnimator.Play ("PlayerStartRunning");
//	}

	public void animationTriggerIdle(){
		fireAnimator.Play ("fireIdle");
	}

//	public void AnimationSetIsRunningTrue(){
//		fireAnimator.SetBool (isRunningHash, true);
//	}
//
//	public void AnimationSetIsRunningFalse(){
//		fireAnimator.SetBool (isRunningHash, false);
//	}
}
