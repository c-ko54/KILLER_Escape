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

    public enum MoveState
    {
        TO_RIGHT,
        TO_LEFT,
        RIGHT_END,
        LEFT_END,     
    };
}
