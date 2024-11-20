using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private GameConst.PlayerTurn currentPlayerTurn;
    private GameConst.PlayerActionState currentPlayerAction;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Player[] players;
    private int actionPlayerID;
    private int movePoint;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPlayerTurn)
        {
            case GameConst.PlayerTurn.PLAYER:
                UpdatePlayerTurn();
                break;
            case GameConst.PlayerTurn.KILLER:
                UpdateKillerTurn();
                break;
            case GameConst.PlayerTurn.MEETING:
                UpdateMeetingTurn();
                break;
        }

        switch (currentPlayerAction)
        {
            case GameConst.PlayerActionState.ACTION:
                UpdateAction();
                break;
            case GameConst.PlayerActionState.ROULETTE:
                UpdateRoulette();
                break;
        }
    }

    private void SetCurrentPlayerTurn(GameConst.PlayerTurn playerTurn)
    {
        currentPlayerTurn = playerTurn;

        switch (currentPlayerTurn)
        {
            case GameConst.PlayerTurn.PLAYER:
                StartPlayerTurn();
                break;
            case GameConst.PlayerTurn.KILLER:
                StartKillerTurn();
                break;
            case GameConst.PlayerTurn.MEETING:
                StartMeetingTurn();
                break;
        }
    }

    private void SetCurrentPlayerAction(GameConst.PlayerActionState playerAction)
    {
        currentPlayerAction = playerAction;

        switch (currentPlayerAction)
        {
            case GameConst.PlayerActionState.ACTION:
                StartAction();
                break;
            case GameConst.PlayerActionState.ROULETTE:
                StartRoulette();
                break;
        }
    }

    
    public void RandomMove()
    {
        movePoint = Random.Range(0, 9);

        if (!players[actionPlayerID].ReturnMoveDir())
        {
            movePoint = movePoint * -1;
        }

        Debug.Log(movePoint);

        mapManager.PlayerMove(movePoint,players[actionPlayerID]);
    }


    private void Initialize()
    {

    }
}
