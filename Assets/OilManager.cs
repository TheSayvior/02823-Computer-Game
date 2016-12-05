using UnityEngine;
using System.Collections;

public class OilManager : MonoBehaviour {

    public GameObject OilFlask;
    // Use this for initialization
    GameObject _player;

    
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        PositionFlask();
        OilFlask.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        if (!OilFlask.activeSelf)
        {
            OilFlask.SetActive(true);
            PositionFlask();
        }

        if(Vector3.Distance(new Vector3(OilFlask.transform.position.x,0,0), new Vector3(_player.transform.position.x,0,0))> 10)
        {
            PositionFlask((int)OilFlask.transform.position.y);
        }

	}

    void PositionFlask()
    {
        int dir = (int)Mathf.Round(Random.Range(0.0f, 1.0f));
        int height = Random.Range(3, 5);
        int side = Random.Range(4, 6);
        switch (dir)
        {
            case 0:
                OilFlask.transform.position = _player.transform.position + new Vector3(-side, height, 0);
                return;

            case 1:
                OilFlask.transform.position = _player.transform.position + new Vector3(side, height, 0);
                return;
        }   
    }
    void PositionFlask(int height)
    {
        int dir = (int)Mathf.Round(Random.Range(0.0f, 1.0f));
        int side = Random.Range(4, 6);
        switch (dir)
        {
            case 0:
                OilFlask.transform.position = _player.transform.position + new Vector3(-side, height, 0);
                return;

            case 1:
                OilFlask.transform.position = _player.transform.position + new Vector3(side, height, 0);
                return;
        }
    }
}
