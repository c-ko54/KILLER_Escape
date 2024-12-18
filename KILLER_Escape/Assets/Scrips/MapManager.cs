using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class MapManager : SingletonBehavior<MapManager>
{
    const float PLAYER_OFFSET_Y = -0.21f;
    const float PLAYER_OFFSET_Z = -0.21f;
    [SerializeField]
    public List<MapArray> mapRows = new List<MapArray>();
    [SerializeField]
    private int remainingSteps;

    private bool moveStartComp;
    void Start()
    {

    }

    void Update()
    {

    }

    public void CalcMoveRange(int move, Player player)
    {
        switch (player.currentMoveState)
        {
            case GameConst.MoveState.TO_RIGHT:
                if (player.GetPosX() + move >= 11)
                {
                    remainingSteps = (player.GetPosX() + move - 11) * -1;

                    PlayerMoveX(11, player);

                    player.SetMoveState(GameConst.MoveState.RIGHT_END);
                }
                else if (player.GetPosX() + move == 11)
                {
                    PlayerMoveX(11, player);

                    player.SetMoveState(GameConst.MoveState.TO_LEFT);

                    SetMoveStartComp(true);
                }
                else
                {
                    PlayerMoveX(move + player.GetPosX(), player);

                    SetMoveStartComp(true);
                }
                break;
            case GameConst.MoveState.TO_LEFT:
                if (player.GetPosX() - move <= 0)
                {
                    remainingSteps = (player.GetPosX() - move) * -1;

                    PlayerMoveX(0, player);

                    player.SetMoveState(GameConst.MoveState.LEFT_END);
                }
                else if (player.GetPosX() - move == 0)
                {
                    PlayerMoveX(0, player);

                    player.SetMoveState(GameConst.MoveState.TO_RIGHT);

                    SetMoveStartComp(true);
                }
                else
                {
                    PlayerMoveX(player.GetPosX() - move, player);

                    SetMoveStartComp(true);
                }
                break;
        }
    }

    public void PlayerMoveX(int move, Player player)
    {
        Transform pPos = player.transform;
        Vector3 mPos;

        mPos = mapRows[player.GetPosY()].mapColumns[move].transform.position;
        pPos.DOMove(Offset(mPos), 1);
        player.UpdatePosX(move);
    }

    public void PlayerMoveY(int move, Player player)
    {
        Transform pPos = player.transform;
        Vector3 mPos;

        mPos = mapRows[player.GetPosY() + move].mapColumns[player.GetPosX()].transform.position;
        pPos.DOMove(Offset(mPos), 1);
        player.UpdatePosY(player.GetPosY() + move);
    }

    public int GetRemainingSteps()
    {
        return remainingSteps;
    }

    public void InitRemainingSteps()
    {
        remainingSteps = 0;
    }

    public void SetMoveStartComp(bool flag)
    {
        moveStartComp = flag;
    }

    public bool GetMoveComp()
    {
        return moveStartComp;
    }

    public Vector3 Offset(Vector3 pos)
    {
        pos.y += PLAYER_OFFSET_Y;
        // pos.z += PLAYER_OFFSET_Z;
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