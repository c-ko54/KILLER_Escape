using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager
{
    public void UpdateCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(actionPlayerID);
            // 現在のプレイヤーのカメラの優先度を高くする
            cameras[i].Priority = (i == actionPlayerID) ? 10 : 0;
            Debug.Log("_"+cameras[i].Priority);
        }
    }
}
