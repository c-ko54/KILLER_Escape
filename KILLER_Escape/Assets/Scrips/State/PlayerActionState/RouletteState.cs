using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using DG.Tweening;

public partial class GameManager
{
    [SerializeField] private GameObject roulette;
    [SerializeField] private GameObject roulettePar;
    [SerializeField] public Animator rouletteAnimater;
    private bool rouletteAnmEnd = false;

    // Start is called before the first frame update
    void StartRoulette()
    {
        InitializeRoulette();
        moveButton[0].SetActive(false);
        roulette.SetActive(true);
        movePoint = Random.Range(3,10);
        Debug.Log(movePoint);
        rouletteAnimater.SetInteger("rouletteCount", movePoint);

        DOVirtual.DelayedCall(4.0f, () =>
        {
            RouletteEnd();
        });
    }

    // Update is called once per frame
    void UpdateRoulette()
    {
        if (!rouletteAnmEnd) { return; }

        DispMoveButton();
        
        if(mapManager.GetMoveComp())
        {
            mapManager.SetMoveStartComp(false);

            rouletteAnmEnd = false;

            SetCurrentPlayerAction(GameConst.PlayerActionState.ACTION_END);
        }  
    }

    void RouletteEnd()
    {
        rouletteAnmEnd = true;
        mapManager.CalcMoveRange(movePoint, players[actionPlayerID]);
        roulette.SetActive(false);
    }

    void InitializeRoulette()
    {
        roulettePar.transform.localEulerAngles = new Vector3(0,0,0);
    }
}
