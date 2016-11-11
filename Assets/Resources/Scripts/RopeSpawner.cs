using UnityEngine;
using System.Collections;

public class RopeSpawner : MonoBehaviour {

    public PlayerShootingController ShootingController;
    public GameObject hingePrefab;
    public GameObject testBlock;
    public GameObject roof;
	// Use this for initialization
	public void spawn () {
        Rigidbody2D previous = null;

	    for (int i = 0; i < ShootingController.rayCastLength * 10; i++)
        {
            float height = 10 -i / 10f;
            Vector2 pos = new Vector2(0, height);
            GameObject placeHolderBecauseIDontKnowBetter = Instantiate(hingePrefab, pos, Quaternion.identity) as GameObject;
            HingeJoint2D ropeSection = placeHolderBecauseIDontKnowBetter.GetComponent<HingeJoint2D>();
            if (previous != null)
            {
                ropeSection.connectedBody = previous;
            } else
            {
                ropeSection.connectedBody = roof.GetComponent<Rigidbody2D>();
            }
            previous = placeHolderBecauseIDontKnowBetter.GetComponent<Rigidbody2D>();
            
        }
        GameObject whatever = Instantiate(testBlock, new Vector2(0, 0), Quaternion.identity) as GameObject;
        whatever.GetComponent<HingeJoint2D>().connectedBody = previous;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
