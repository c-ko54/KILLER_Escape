using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class MapManager : SingletonBehavior<MapManager>
{
    const float PLAYER_OFFSET_Y = 0.23f;
    const float PLAYER_OFFSET_Z = -0.2f;
    [SerializeField]
    public List<MapArray> mapRows = new List<MapArray>();
    [SerializeField]
    private int remainingSteps;
    private float moveTime;
    private bool moveStartComp;
    void Start()
    {

    }

    void Update()
    {

    }

    public void SetMoveTime(int moveCount)
    {
        moveTime = 0.5f * moveCount;
    }

    public void CalcMoveRange(int moveCount, Player player)
    {
        SetMoveTime(moveCount);

        switch (player.currentMoveState)
        {
            case GameConst.MoveState.TO_RIGHT:
                if (player.GetPosX() + moveCount >= 11)
                {
                    remainingSteps = (player.GetPosX() + moveCount - 11) * -1;

                    PlayerMoveX(11, player);

                    player.SetMoveState(GameConst.MoveState.RIGHT_END);
                }
                else if (player.GetPosX() + moveCount == 11)
                {
                    PlayerMoveX(11, player);

                    player.SetMoveState(GameConst.MoveState.TO_LEFT);

                    SetMoveStartComp();
                }
                else
                {
                    PlayerMoveX(moveCount + player.GetPosX(), player);

                    SetMoveStartComp();
                }
                break;
            case GameConst.MoveState.TO_LEFT:
                if (player.GetPosX() - moveCount <= 0)
                {
                    remainingSteps = (player.GetPosX() - moveCount) * -1;

                    PlayerMoveX(0, player);

                    player.SetMoveState(GameConst.MoveState.LEFT_END);
                }
                else if (player.GetPosX() - moveCount == 0)
                {
                    PlayerMoveX(0, player);

                    player.SetMoveState(GameConst.MoveState.TO_RIGHT);

                    SetMoveStartComp();
                }
                else
                {
                    PlayerMoveX(player.GetPosX() - moveCount, player);

                    SetMoveStartComp();
                }
                break;
        }
    }

    public void PlayerMoveX(int dest, Player player)
    {
        Transform pPos = player.transform;
        Vector3 mPos;

        mPos = mapRows[player.GetPosY()].mapColumns[dest].transform.position;
        pPos.DOMove(Offset(mPos), moveTime)
        .SetEase(Ease.InOutSine);
        player.UpdatePosX(dest);
    }

    public void PlayerMoveY(int dest, Player player)
    {
        Transform pPos = player.transform;
        Vector3 mPos;

        mPos = mapRows[player.GetPosY() + dest].mapColumns[player.GetPosX()].transform.position;
        pPos.DOMove(Offset(mPos), 1);
        player.UpdatePosY(player.GetPosY() + dest);
    }

    public int GetRemainingSteps()
    {
        return remainingSteps;
    }

    public void InitRemainingSteps()
    {
        remainingSteps = 0;
    }

    public void SetMoveStartComp()
    {
        if(!moveStartComp) moveStartComp = true;

        else moveStartComp = false;
    }

    public bool GetMoveStartComp()
    {
        return moveStartComp;
    }

    public Vector3 Offset(Vector3 pos)
    {
        pos.y += PLAYER_OFFSET_Y;
        pos.z += PLAYER_OFFSET_Z;
        return pos;
    }

    public Vector3 GetStartPos()
    {
        Vector3 pos;
        pos = mapRows[0].mapColumns[0].transform.position;
        return Offset(pos);
    }
}

[System.Serializable]
public class MapArray
{
    public List<GameObject> mapColumns;
}