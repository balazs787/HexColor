﻿using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Color color;
    public string playerName;
    public int id;
    public bool ai;
    public HexagonField startingHex;
    private int _numberOfHexes;

    public int GetId()
    {
        return id;
    }

    public void ChooseColor(Material material)
    {
        startingHex.SetColor(material);
        color = material.color;
    }

    private void Start()
    {
        if(color == Color.clear)
        {
            color = Color.black;
        }

    }

    public void AddHex()
    {
        _numberOfHexes++;
    }

    public int GetHexes()
    {
        return _numberOfHexes;
    }
}
