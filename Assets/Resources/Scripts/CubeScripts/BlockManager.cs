using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {



    public GameObject StandartCube;
    public GameObject Pool;

    public float cubeSpawnTime = 0.1f;
    public float cubeMoveTime = 2.5f;
    public float chooseCubeToMoveTime = 1.5f;
    public int blocksToSpawnInPool = 20;


    public GameObject[] BlockPool;
    public GameObject[] BlockPositions;

  
    static public int Width = 10;
    static public int Height = 10;

    RaycastHit hit;
    GameObject spawnedObj = null;

    // Use this for initialization

    void Start () {
        //Spawn the required amount of blocks in the pool
        for (int i = 0; i < blocksToSpawnInPool; i++)
        {
            spawnedObj = null;
            spawnedObj = (GameObject) Instantiate(StandartCube, Vector3.zero, Quaternion.identity);
            spawnedObj.transform.parent = Pool.transform;
        }

        //Put in the blocks spawned in the pool to the array.
        BlockPool = new GameObject[Pool.transform.childCount];
        for(int i= 0; i< BlockPool.Length; i++)
        {
            BlockPool[i] = Pool.transform.GetChild(i).gameObject;
        }
        //Spawn the first cube below the player.
        BlockPool[0].transform.position = new Vector2(Mathf.Round(Camera.main.transform.position.x), Mathf.Round(Camera.main.transform.position.y) - 1);
        BlockPool[0].SetActive(true);
        //Start Spawning cubes randomly.
        StartCoroutine(SpawnCube());
   }

    private void CreateCube(int attempt)
    {
        if(attempt== 10) // if we try to many times just end the shit
        {
            Debug.Log("Cant find available spot");
            return;
        }

        int x = Random.Range(1, 10);
        int y = Random.Range(1, 10);

        int NorP = Random.Range(0, 4);
        switch (NorP)
        {
            case 0:
                break;
            case 1:
                x = - x;
                break;
            case 2:
                y = - y;
                break;
            case 3:
                x = - x;
                y = - y;
                break;
            case 4:
                break;
        }

        Vector3 fwd = -(Camera.main.transform.position - new Vector3(Mathf.Round(Camera.main.transform.position.x) + x, Mathf.Round(Camera.main.transform.position.y) + y, 0));

        if (Physics.SphereCast(Camera.main.transform.position, 0.9f, fwd, out hit, 20))
        {
            if(hit.transform.gameObject.tag == "Block")
            {
                CreateCube(attempt+1);
                return;
            } 
        }

        //Find an unactive cube to be used and place at the available location
        for (int i = 0; i < BlockPool.Length; i++)
        {
            if (BlockPool[i].activeSelf == false)
            {

                BlockPool[i].transform.position = new Vector2(Mathf.Round(Camera.main.transform.position.x) + x, Mathf.Round(Camera.main.transform.position.y) + y);
                BlockPool[i].SetActive(true);
                return;
            }
        }
        //We are out of cubes if you're not dead then you should be
        Debug.Log("Out of blocks to spawn");
    }

    IEnumerator SpawnCube()
    {
        CreateCube(0);
        yield return new WaitForSeconds(cubeSpawnTime);

        StartCoroutine(SpawnCube());
        yield return null;
    }
}
