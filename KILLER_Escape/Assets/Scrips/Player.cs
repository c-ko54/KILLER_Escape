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


    void Start()
    {
        //moveDir = true;
    }

    public void SetMoveDir(bool moveDir)
    {
        this.moveDir = moveDir;
    }

    public bool ReturnMoveDir()
    {
        return moveDir;
    }

    public int returnPosX()
    {
        return posX;
    }

    public int ReturnPosY()
    {
        return posY;
    }


    public void UpdatePos(int x, int y)
    {
        posX = x;
        posY = y;
    }

}
