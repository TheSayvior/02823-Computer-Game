using UnityEngine;
using System.Collections;

public class CheckSpace : MonoBehaviour {

    BlockManager BlockManagement;

    public bool free = true;

    float timer;
    
    void Start ()
    {
        BlockManagement = this.gameObject.transform.parent.gameObject.GetComponent<BlockManager>();
    }
	
    void OnEnable()
    {
        free = true;
        timer = Time.deltaTime + 0.5f;
    }

    void Update()
    {
        if (Time.deltaTime <= timer)
        {
            return;
        }

        if (free)
        {
            BlockManagement.PlaceBlock();
            this.gameObject.SetActive(false);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Block")
            {
                free = false;
            }
        Debug.Log("Position already in use");
        BlockManagement.PositionCube();
        this.gameObject.SetActive(false);
    }
}
