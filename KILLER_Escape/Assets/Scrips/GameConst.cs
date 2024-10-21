using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConst
{
    public enum  PlayerTurn
    {
        PLAYER,
        KILLER,
        MEETING,
        TURN_END,
    };

    public enum PlayerActionState
    {
        ACTION,
        ROULETTE,
        ACTION_END,
    };
}
