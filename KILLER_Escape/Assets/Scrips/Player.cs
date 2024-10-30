using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int id;
    private string playername;
    private int hp;
    private bool killer;
    
    private List<int> haveCard;
    private List<int> encounter;

    void Start()
    {

    }
    public void SetId(int ID)
    {
        id = ID;
    }

    public void GetCard(int CardID)
    {
        if(haveCard.Count < 6)
        {
            haveCard.Add(CardID);
        }
    }

    public void DestroyCard(int CardID)
    {
        if(haveCard.Contains(CardID))
        {
            haveCard.Remove(CardID);
        }
    }

    public void GetEncounter(int ID)
    {
        if(encounter.Contains(ID) != false)
        {
            encounter.Add(ID);
        }
    }
}