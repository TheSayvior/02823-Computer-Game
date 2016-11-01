using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

    public GameObject StandartCube;

    public GameObject[] BlockPool;
    public GameObject[] BlockPositions;

    public float CubeSpawnTime = 0.5f;
    public float CubeMoveTime = 1.5f;
    public float ChooseCubeToMoveTime = 1.5f;

    static public int Width = 10;
    static public int Height = 10;
    
    // Use this for initialization

	void Start () {

        StartCoroutine(SpawnCube());


    }

    private void CreateCube()
    {
        int x = Random.Range(3, Width);
        int y = Random.Range(3, Height);

        Vector3 fwd = Camera.main.transform.position - new Vector3(x, y, 0);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if(hit.transform.gameObject.tag == "Block")
            {
                CreateCube();
                return;
            }

            // Do something with the object that was hit by the raycast.
        }

        for (int i = 0; i<BlockPool.Length; i++)
        {
            if(BlockPool[i].activeSelf == false)
            {
                
                BlockPool[i].transform.position = new Vector2(Camera.main.transform.position.x + x, Camera.main.transform.position.y + y);
                BlockPool[i].SetActive(true);
                return;
            }
        }

        Debug.Log("Out of blocks to spawn");
    }

    IEnumerator SpawnCube()
    {
        CreateCube();
        yield return new WaitForSeconds(CubeSpawnTime);

        StartCoroutine(SpawnCube());
        yield return null;
    }
}
