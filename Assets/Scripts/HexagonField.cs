﻿using UnityEngine;

public class HexagonField : Field
{
    [System.Serializable]
    public class Neighbours
    {
        public GameObject topRight;
        public GameObject right;
        public GameObject bottomRight;
        public GameObject bottomLeft;
        public GameObject left;
        public GameObject topLeft;
    }

    public Neighbours neighbours;
    private HexagonField[] _hexes;
    public bool Active;
    public Player _player;
    private bool _checked;

    private void Awake()
    {
        gameObject.SetActive(Active);

        _hexes = new HexagonField[6];
        if(neighbours.topRight != null)
        {
            _hexes[0] = neighbours.topRight.GetComponent<HexagonField>();
        }
        if (neighbours.right != null)
        {
            _hexes[1] = neighbours.right.GetComponent<HexagonField>();
        }
        if (neighbours.bottomLeft != null)
        {
            _hexes[2] = neighbours.bottomLeft.GetComponent<HexagonField>();
        }
        if (neighbours.bottomRight != null)
        {
            _hexes[3] = neighbours.bottomRight.GetComponent<HexagonField>();
        }
        if (neighbours.left != null)
        {
            _hexes[4] = neighbours.left.GetComponent<HexagonField>();
        }
        if (neighbours.topLeft != null)
        {
            _hexes[5] = neighbours.topLeft.GetComponent<HexagonField>();
        } 
    }

    public void SetColor(Material material)
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
        _checked = true;
        foreach (var hex in _hexes)
        {
            if(hex != null && !hex.GetChecked() && hex.GetPlayer() == FindObjectOfType<GameController>().GetPlayer())
            {
                hex.SetColor(material);
            }
        }
        CheckColor(material);
    }

    public void CheckColor(Material material)
    {
        foreach (var hex in _hexes)
        {
            if (hex != null && hex.GetPlayer() == null && hex.GetColor() == material.color)
            {
                hex.SetPlayer(FindObjectOfType<GameController>().GetPlayer());
                FindObjectOfType<GameController>().GetPlayer().AddHex();
                hex.CheckColor(material);
            }
        }
    }

    public Color GetColor()
    {
        return gameObject.GetComponent<MeshRenderer>().material.color;
    }

    public void SetPlayer(Player player)
    {
        this._player = player;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public bool GetChecked()
    {
        return _checked;
    }

    public void ResetChecked()
    {
        _checked = false;
    }

    override
    public void Activate()
    {

    }

    public HexagonField() : base()
    {

    }

}
