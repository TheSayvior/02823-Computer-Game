using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

    public GameObject StandartCube;
    public GameObject SpaceChecker;
    public GameObject Pool;

    public GameObject[] BlockPool;
    public GameObject[] BlockPositions;

    public float CubeSpawnTime = 0.5f;
    public float CubeMoveTime = 1.5f;
    public float ChooseCubeToMoveTime = 1.5f;

    static public int Width = 2;
    static public int Height = 2;

    Vector2 placement;
    int attempts = 0;
    
    // Use this for initialization

	void Start () {

        BlockPool = new GameObject[Pool.transform.childCount];

        for (int i = 0; i < Pool.transform.childCount; i++)
        {
            BlockPool[i] = Pool.transform.GetChild(i).gameObject;
        }

        StartCoroutine(SpawnCube());


    }

    public void PositionCube()
    {
        int x = Random.Range(0, Width);
        int y = Random.Range(0, Height);

        placement = new Vector2(Camera.main.transform.position.x - Width / 2 + x, Camera.main.transform.position.y - Height / 2 + y);

        SpaceChecker.transform.position = placement;
        SpaceChecker.SetActive(true);

    }

    public void PlaceBlock()
    {
        for (int i = 0; i < BlockPool.Length; i++)
        {
            if (BlockPool[i].activeSelf == false)
            {
                attempts = 0;
                BlockPool[i].transform.position = placement;
                BlockPool[i].SetActive(true);
                return;
            }
        }

        Debug.Log("Out of blocks to spawn");
    }

    IEnumerator SpawnCube()
    {
        PositionCube();
        yield return new WaitForSeconds(CubeSpawnTime);

        while(SpaceChecker.activeSelf == true)
        {
            yield return new WaitForSeconds(0.5f);
        }

        StartCoroutine(SpawnCube());
        yield return null;
    }
}
