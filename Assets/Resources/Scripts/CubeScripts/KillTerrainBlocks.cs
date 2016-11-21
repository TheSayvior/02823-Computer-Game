using UnityEngine;
using System.Collections;

public class KillTerrainBlocks : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.gameObject.tag == "Block")
        {
            Object.transform.gameObject.SetActive(false);
        }
    }
}
