using UnityEngine;
using System.Collections;

public class OilFlask : MonoBehaviour {

    PlayerStats playerValues;
    
    // Use this for initialization
	void Start () {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}

    void Update()
    {
        transform.RotateAround(this.gameObject.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D obj)
    {
        /*if(obj.tag == "Block")
        {
            StartCoroutine(DeathByCube());
        }*/

        if (obj.tag == "Player")
        {
            //Add flask size value to player flame oil pool
            obj.GetComponent<PlayerStats>().ActivateFlask();

            //removes the obj from the scene
            this.gameObject.SetActive(false);
            
        }
    }

    IEnumerator DeathByCube()
    {
        //Play break animation and wait for it to finish
        Destroy(this.gameObject);
        yield return null;
    }
}
