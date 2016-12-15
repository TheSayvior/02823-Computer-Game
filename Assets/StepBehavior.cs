using UnityEngine;
using System.Collections;

public class StepBehavior : MonoBehaviour {

    public AudioSource Step1, Step2, Step3, Step4;

    public bool PlayStepSounds;

    public float stepDelay = 0.25f;

    Rigidbody2D _playerRB;

    float _timer;

	// Use this for initialization
	void Start () {
        PlayStepSounds = true;
        _playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        if (PlayStepSounds && (_timer > stepDelay) && (_playerRB.velocity.x* _playerRB.velocity.x) > 0)
        {
            int caseValue = Random.Range(0, 5);
            switch (caseValue)
            {
                case 1:
                    Step1.Play();
                    break;
                case 2:
                    Step2.Play();
                    break;
                case 3:
                    Step3.Play();
                    break;
                case 4:
                    Step4.Play();
                    break;
            }
            _timer = 0;
        }
    }
}
