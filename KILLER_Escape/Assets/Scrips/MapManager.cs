using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;
using Unity.VisualScripting;

public class MapManager : SingletonBehavior<MapManager>
{
    private const float PLAYER_OFFSET_Y = 0.23f;
    private const float PLAYER_OFFSET_Z = -0.2f;
    [SerializeField]
    public List<MapArray> mapRows = new List<MapArray>();
    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayerMove(int move, Player player)
    {
        Transform pPos = player.transform;
        Vector3 mPos;

        if (player.returnPosX() + move <= 0)
        {
            mPos = mapRows[player.ReturnPosY()].mapColumns[0].transform.position;
            mPos.y += PLAYER_OFFSET_Y;
            mPos.z += PLAYER_OFFSET_Z;
            pPos.DOMove(mPos, 1);
            player.SetMoveDir(true);
        }
        else if (player.returnPosX() + move >= 11)
        {
            mPos = mapRows[player.ReturnPosY()].mapColumns[11].transform.position;
            mPos.y += PLAYER_OFFSET_Y;
            mPos.z += PLAYER_OFFSET_Z;
            pPos.DOMove(mPos, 1);
            player.SetMoveDir(false);
        }
        else
        {
            mPos = mapRows[player.ReturnPosY()].mapColumns[move + player.returnPosX()].transform.position;
            mPos.y += PLAYER_OFFSET_Y;
            mPos.z += PLAYER_OFFSET_Z;
            pPos.DOMove(mPos, 1);
        }
    }


}

[System.Serializable]
public class MapArray
{
    public List<GameObject> mapColumns;
}