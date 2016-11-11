using UnityEngine;
using System.Collections;

public class HookShotScript : MonoBehaviour
{


    public GameObject hook;
    public float maxRopeLength;
    public LayerMask myLayermask;
    public bool ropeActive;

    private GameObject curHook;
    private GameObject blockAnchor;
    private Vector2 curPosition;
    private Vector2 shootDirection;
    private RaycastHit2D hitinfo;
    
    private PlayerMovementController playerMC;
    private Rigidbody2D playerRB;


    // Use this for initialization
    void Start()
    {
        ropeActive = false;
        playerMC = this.GetComponent<PlayerMovementController>();
        playerRB = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            DestroyCurHook();
            if (HitCheck())
            {
                ShootHook();
            }
            else
            {
                FakeShootHook();
                StartCoroutine(playerMC.standup());
                playerRB.freezeRotation = true;		//stops player from rotating when not connected to rope
            }
        }
        
        if (Input.GetMouseButtonDown(1) && ropeActive)
        {
            DestroyCurHook();
            StartCoroutine(playerMC.standup());
            playerRB.freezeRotation = true;		//stops player from rotating when not connected to rope
        }



    }

    public void DestroyCurHook()
    {
        ropeActive = false;
        if (blockAnchor != null)
        {
            blockAnchor.GetComponent<BlockMovementController>().ropeAttached = false;
        }
        Destroy(curHook);
    }

    private void ShootHook()
    {        
        curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
        curHook.GetComponent<RopeScript>().destiny = new Vector2(hitinfo.point.x, hitinfo.point.y);
        curHook.GetComponent<RopeScript>().killMeAtDestination = false;
    }

    private void FakeShootHook()
    {
        curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
        curHook.GetComponent<RopeScript>().destiny = new Vector2 (this.transform.position.x, this.transform.position.y) + (shootDirection.normalized * maxRopeLength);
        curHook.GetComponent<RopeScript>().killMeAtDestination = true;
    }

    private bool HitCheck()
    {
        curPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        shootDirection = (new Vector2(-0.5f, -0.5f) + new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x, Camera.main.ScreenToViewportPoint(Input.mousePosition).y));
        hitinfo = Physics2D.Raycast(curPosition, shootDirection, maxRopeLength, myLayermask);

        if (hitinfo.collider != null && hitinfo.collider.tag == "Block")
        {
            blockAnchor = hitinfo.collider.gameObject;
            blockAnchor.GetComponent<BlockMovementController>().ropeAttached = true;
            Debug.Log("Hitcheck: " + hitinfo.collider.transform.position + " FakePos: " + shootDirection.normalized * 2);
            return true;
        }
        return false;
    }
}