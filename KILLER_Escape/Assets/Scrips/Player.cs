using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int posX;
    [SerializeField]
    private int posY;
    //進行方向
    [SerializeField]
    private bool moveDir;

    private int playerID;

    int steps;

    public GameConst.MoveState currentMoveState;


    void Start()
    {
        moveDir = true;
        currentMoveState=GameConst.MoveState.TO_RIGHT;
    }

    public void SetMoveDir(bool moveDir)
    {
        this.moveDir = moveDir;
    }

    public void SetPlayerID(int playerID)
    {
        this.playerID = playerID;
    }

    public void SetMoveState(GameConst.MoveState moveState)
    {
        currentMoveState = moveState;
    }

    public void SetSteps(int steps)
    {
        this.steps = steps;
    }

    public int GetSteps()
    {
        return steps;
    }

    public bool GetMoveDir()
    {
        return moveDir;
    }

    public int GetPosX()
    {
        return posX;
    }

    public int GetPosY()
    {
        return posY;
    }


    public void UpdatePosX(int x)
    {
        posX = x;
    }

    public void UpdatePosY(int y)
    {
        posY = y;
    }
}
