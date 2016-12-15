using UnityEngine;
using System.Collections;

public class StandartFlameAudioBehavior : MonoBehaviour {

    AudioSource _flame;
	// Use this for initialization
	void Start () {
        _flame = this.gameObject.GetComponent<AudioSource>();
	}
	
	public void FlameSoundUpdate(float volume)
    {
        _flame.volume = volume;
    }
}
