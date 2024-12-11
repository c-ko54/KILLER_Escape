using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public partial class GameManager
{
    private async void StartActionEnd()
    {
        if (actionPlayerID == 3)
        {
            actionPlayerID = 0;
            await WaitTime(2);
            UpdateCamera();
        }
        else
        {
            actionPlayerID++;
            await WaitTime(2);
            UpdateCamera();
        }
    }

    private void UpdateActionEnd()
    {
        SetCurrentPlayerAction(GameConst.PlayerActionState.ACTION);
    }

    public async UniTask WaitTime(int time)
    {
        await UniTask.Delay(time * 1000);
    }
}