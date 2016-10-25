using UnityEngine;
using System.Collections;

public class PlayerShootingScript : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    //public LayerMask ToHit;

    float timeToFire = 0;

    Transform firePoint;

	// Use this for initialization
	void Start () {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
        if (fireRate == 0)
        {
            // Or getkeycode
            if (Input.GetKey("f"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

   void Shoot() {
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,  Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        // No firepoint for gun yet
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 5);
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);

        Debug.Log(hit.collider.gameObject.tag);

        if (hit.collider.gameObject.tag == "ropeable")
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        }

    }


    public Vector2 publicShoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        // No firepoint for gun yet
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 5);
       
        Debug.Log(hit.point.x + "   "  + hit.point.y);
        return new Vector2(hit.point.x, hit.point.y);
    }
}

