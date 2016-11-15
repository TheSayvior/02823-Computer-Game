using UnityEngine;
using System.Collections;

public class BlockSpaceCheck : MonoBehaviour {

    public bool Right, Left, Up, Down;

    BlockMovementController BlockControl;

	// Use this for initialization
	void Start () {
        BlockControl = this.gameObject.transform.parent.GetComponent<BlockMovementController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Object)
    {
        if(Object.gameObject.tag == "Block")
        {
            if (Right)
            {
                BlockControl.rightSpace = false;
            }
            if (Left)
            {
                BlockControl.leftSpace = false;
            }
            if (Up)
            {
                BlockControl.upSpace = false;
            }
            if (Down)
            {
                BlockControl.downSpace = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D Object)
    {
        if (Object.gameObject.tag == "Block")
        {
            if (Right)
            {
                BlockControl.rightSpace = true;
            }
            if (Left)
            {
                BlockControl.leftSpace = true;
            }
            if (Up)
            {
                BlockControl.upSpace = true;
            }
            if (Down)
            {
                BlockControl.downSpace = true;
            }
        }
    }
}
