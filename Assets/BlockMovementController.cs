using UnityEngine;
using System.Collections;

public class BlockMovementController : MonoBehaviour {

    BlockManager BlockManagment;

    public float moveTime = 3.0f;

    public bool leftSpace = true;
    public bool rightSpace = true;
    public bool upSpace = true;
    public bool downSpace = true;

    public bool movable = true;
    public bool moving = false;


    int dirAmount;  //amount of movable directions
    int dir;        //random integer between 0 and amount of movable directions

    void Start()
    {
        BlockManagment = FindObjectOfType<BlockManager>();
    }

    public void UpdateMoveable()
    {
        if(leftSpace || rightSpace || upSpace || downSpace)
        {
            movable = true;
        }else
        {
            movable = false;
        }
    }

    public void MoveBlock()
    {
        StartCoroutine(Move(DetermineDirection()));
    }

    //Chooses the given side if it happens to be the one that counts the random integer down below zero
    private Vector2 ChooseFreeSide(bool side, Vector2 vectorSide)
    {
        if(side == true)
        {
            dir--;
            if(dir < 0)
            {
                return vectorSide;
            }
        }

        return new Vector2(0,0);
    }

    //detemiunes the direction we move in
    private Vector2 DetermineDirection()
    {
        Vector2 direction = new Vector2(0, 0);
        //available directions
        dirAmount = AmountOfMoveableDirections();
         
        //Choose direction
        dir = (int)Random.Range(0, dirAmount - 1);

        if(direction == Vector2.zero)
            direction = ChooseFreeSide(leftSpace, new Vector2(-1, 0));
        if (direction == Vector2.zero)
            direction = ChooseFreeSide(rightSpace, new Vector2(1, 0));
        if (direction == Vector2.zero)
            direction = ChooseFreeSide(upSpace, new Vector2(0, 1));
        if (direction == Vector2.zero)
            direction = ChooseFreeSide(downSpace, new Vector2(0, -1));
        
        return direction;
    }

    //moves the cube
    IEnumerator Move(Vector2 direction)
    {
        moving = true;
        Vector2 startPos = this.transform.position;
        Vector2 endPos = startPos + direction;

        //removes the block from the block manager so it dosent try to move it
        BlockManagment.RemoveBlock(this.gameObject, startPos);
        
        float elapsedTime = 0.0f;
         
        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / moveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        moving = false;
        UpdateMoveable();
        
        //adds the block to the block manager so it can move it
        BlockManagment.AddBlock(this.gameObject, startPos);

        yield return null;
    }

    private int AmountOfMoveableDirections()
    {
        int space = 0;
        if (leftSpace)
            space++;
        if (rightSpace)
            space++;
        if (upSpace)
            space++;
        if (downSpace)
            space++;

        return space;
    }

}
