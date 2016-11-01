﻿using UnityEngine;
using System.Collections;

public class PlayerShootingController : MonoBehaviour {


    //public LayerMask ToHit;
    Transform firePoint;
    public Vector2 ropeHitPosition;
    public GameObject hitGameObject;
    public int rayCastLength;

	// Use this for initialization
	void Start () {
		rayCastLength = 5;
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
        debugShoot();
	}

   void debugShoot() {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,  Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, rayCastLength);
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);

		if (hit.collider != null && (hit.collider.gameObject.tag == "ropeable" || hit.collider.gameObject.tag == "Block"))
        {
            Debug.Log(hit.collider.gameObject.tag);
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }

    }


    public bool publicShoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, rayCastLength);
		if (hit.collider != null && (hit.collider.gameObject.tag == "ropeable"|| hit.collider.gameObject.tag == "Block"))
        {
            hitGameObject = hit.collider.gameObject;
            ropeHitPosition = new Vector2(hit.point.x, hit.point.y);
            return true;
        }

        return false;
        
    }

    
}

