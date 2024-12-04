using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager
{
    private void StartActionEnd()
    {
        if (actionPlayerID == 3)
        {
            actionPlayerID = 0;
        }
        else
        {
            actionPlayerID++;
        }
    }

    private void UpdateActionEnd()
    {
        SetCurrentPlayerAction(GameConst.PlayerActionState.ACTION);
    }
}
