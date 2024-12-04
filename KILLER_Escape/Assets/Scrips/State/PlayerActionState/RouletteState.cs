using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager
{
    // Start is called before the first frame update
    void StartRoulette()
    {
        moveButton[0].SetActive(false);
        //TODO ルーレットのアニメーションの再生
    }

    // Update is called once per frame
    void UpdateRoulette()
    {
        DispMoveButton();
        
        if(mapManager.GetMoveComp())
        {
            mapManager.SetMoveComp(false);

            SetCurrentPlayerAction(GameConst.PlayerActionState.ACTION_END);
        }
    }
}
