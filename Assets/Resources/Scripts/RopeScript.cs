using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RopeScript : MonoBehaviour
{
    public bool killMeAtDestination;
    public GameObject nodePrefab;
    public GameObject player;
    public GameObject lastNode;
    public Vector2 destiny;
    public float speed = 5f;
    public float distance = 0.025f;
    bool done = false;

    private Vector2 origin;
    private float maxRopeLength;
    private Rigidbody2D connectedBlock;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = this.transform.gameObject;
        origin = this.transform.position;
        maxRopeLength = player.GetComponent<HookShotScript>().maxRopeLength;
        connectedBlock = this.GetComponent<HingeJoint2D>().connectedBody;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(origin, this.transform.position) >= maxRopeLength - 0.5f && killMeAtDestination || Vector2.Distance(player.transform.position, destiny) > maxRopeLength + 1)
        {
            player.GetComponent<HookShotScript>().DestroyCurHook();
        }

        this.transform.position = Vector2.MoveTowards(transform.position, destiny, (speed) * Time.deltaTime);

        if (!done && Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
        {
            CreateNode();
        }

        else if (done == false && (Vector2)this.transform.position == destiny)
        {
            done = true;
            player.GetComponent<Rigidbody2D>().freezeRotation = false;
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            player.GetComponent<HookShotScript>().ropeActive = true;

        }



    }


    void CreateNode()
    {

        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;

        GameObject go = (GameObject)Instantiate(nodePrefab, pos2Create, Quaternion.identity);
        go.transform.SetParent(this.transform);
        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();
        lastNode = go;

    }



}