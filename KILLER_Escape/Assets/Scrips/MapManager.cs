using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SingletonBehavior<MapManager>
{
    public ChildArray[] row;
    void Start()
    {

    }

    void Update()
    {

    }
}

[System.Serializable]
public class ChildArray
{
    public GameObject[] column;
}