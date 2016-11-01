using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

    public GameObject StandartCube;
    public int blocksToSpawn = 20;

    static public int Width = 20;
    static public int Height = 20;
    
    // Use this for initialization

    public GameObject[,] Block = new GameObject[Width, Height];

	void Start () {
        StartCoroutine(SpawnCube());
        StartCoroutine(MoveACube());
    }

    public void AddBlock(GameObject AddBlock, Vector2 position)
    {
        Block[(int)position.x - (int)Camera.main.transform.position.x, (int)position.y - (int)Camera.main.transform.position.y] = AddBlock;
    }

    public void RemoveBlock(GameObject Removeblock, Vector2 position)
    {
        Block[(int)position.x - (int)Camera.main.transform.position.x, (int)position.y - (int)Camera.main.transform.position.y] = null;
    }

    private void CreateCube()
    {
        int x = Random.Range(0, Width);
        int y = Random.Range(0, Height);

        if(Block[x,y] != null)
        {
            CreateCube();
            return;
        }

        GameObject obj = (GameObject)Instantiate(StandartCube, new Vector3(x + (int)Camera.main.transform.position.x - (Width/2), y + (int)Camera.main.transform.position.y - (Height / 2), 0), Quaternion.identity);
        obj.SetActive(true);
    }

    IEnumerator SpawnCube()
    {
        CreateCube();
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(SpawnCube());
        yield return null;
    }

    IEnumerator MoveACube()
    {
        yield return new WaitForSeconds(1.0f);
        MoveRandomCube();
        StartCoroutine(MoveACube());
        yield return null;
    }

    private void MoveRandomCube()
    {
        int x = Random.Range(0, Width);
        int y = Random.Range(0, Height);

    }
}
