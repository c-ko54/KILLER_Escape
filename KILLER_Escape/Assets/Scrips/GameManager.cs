using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    private GameConst.PlayerTurn currentPlayerTurn;
    private GameConst.PlayerActionState currentPlayerAction;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Player[] player = new Player[4];
    public Player[] players = new Player[4];

    [SerializeField]
    private GameObject[] moveButton = new GameObject[5];

    [SerializeField]
    private int actionPlayerID;
    private int movePoint = 0;


    void Start()
    {
        SpawnPlayer();
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
            case GameConst.PlayerActionState.ACTION_END:
                UpdateActionEnd();
                break;
        }
    }

    private void SpawnPlayer()
    {
        for (int i = 0; i < 4; i++)
        {
            players[i] = Instantiate(player[i], mapManager.GetStartPos(), Quaternion.identity);
            players[i].SetPlayerID(i);
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
            case GameConst.PlayerActionState.ACTION_END:
                StartActionEnd();
                break;
        }
    }

    public void StartRouletteAction()
    {
        SetCurrentPlayerAction(GameConst.PlayerActionState.ROULETTE);
    }

    public void DispMoveButton()
    {
        switch (players[actionPlayerID].currentMoveState)
        {
            case GameConst.MoveState.RIGHT_END:
                moveButton[4].SetActive(true);
                break;
            case GameConst.MoveState.LEFT_END:
                moveButton[3].SetActive(true);
                break;
        }

        if (players[actionPlayerID].currentMoveState == GameConst.MoveState.RIGHT_END
        || players[actionPlayerID].currentMoveState == GameConst.MoveState.LEFT_END)
        {
            if (players[actionPlayerID].GetPosY() == 0)
            {
                moveButton[1].SetActive(true);
                moveButton[2].SetActive(false);
            }
            else if (players[actionPlayerID].GetPosY() == 3)
            {
                moveButton[1].SetActive(false);
                moveButton[2].SetActive(true);
            }
            else
            {
                moveButton[1].SetActive(true);
                moveButton[2].SetActive(true);
            }
        }

        if (players[actionPlayerID].currentMoveState == GameConst.MoveState.RIGHT_END)
        {
            moveButton[3].SetActive(false);
            moveButton[4].SetActive(true);
        }
        else if (players[actionPlayerID].currentMoveState == GameConst.MoveState.LEFT_END)
        {
            moveButton[3].SetActive(true);
            moveButton[4].SetActive(false);
        }
        else
        {
            moveButton[1].SetActive(false);
            moveButton[2].SetActive(false);
            moveButton[3].SetActive(false);
            moveButton[4].SetActive(false);
        }
    }

    private void InitButton()
    {
        for(int i = 0; i < 4;i++)
        {
            moveButton[i].SetActive(false);
        }
    }

    public void Up()
    {
        mapManager.PlayerMoveY(+1, players[actionPlayerID]);
    }

    public void Down()
    {
        mapManager.PlayerMoveY(-1, players[actionPlayerID]);
    }

    public void Right()
    {
        mapManager.PlayerMoveX(players[actionPlayerID].GetPosX() + mapManager.GetRemainingSteps(), players[actionPlayerID]);
        mapManager.InitRemainingSteps();
        players[actionPlayerID].SetMoveState(GameConst.MoveState.TO_RIGHT);
        mapManager.SetMoveComp(true);
    }

    public void Left()
    {
        mapManager.PlayerMoveX(players[actionPlayerID].GetPosX() + mapManager.GetRemainingSteps(), players[actionPlayerID]);
        mapManager.InitRemainingSteps();
        players[actionPlayerID].SetMoveState(GameConst.MoveState.TO_LEFT);
        mapManager.SetMoveComp(true);
    }

    private void Initialize()
    {

    }
}
