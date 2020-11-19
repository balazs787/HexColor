using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexmapGenerator : MonoBehaviour
{
    public GameObject[,] hexagons;
    void Start()
    {
        hexagons = new GameObject[50, 50];
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                Vector3 pos = new Vector3((float)(i * (-1.75)) + (float)(j * (-0.875)), 0, (float)(j * 1.52));
                GameObject newHex = Instantiate(Resources.Load<GameObject>("Hex"), transform);
                newHex.transform.position = pos;
                hexagons[i, j] = newHex;
            }
        }

        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                hexagons[i, j].GetComponent<HexagonField>().neighbours.left = GetHex(i - 1, j);
                hexagons[i, j].GetComponent<HexagonField>().neighbours.topLeft = GetHex(i, j - 1);
                hexagons[i, j].GetComponent<HexagonField>().neighbours.topRight = GetHex(i + 1, j - 1);
                hexagons[i, j].GetComponent<HexagonField>().neighbours.right = GetHex(i + 1, j);
                hexagons[i, j].GetComponent<HexagonField>().neighbours.bottomRight = GetHex(i, j + 1);
                hexagons[i, j].GetComponent<HexagonField>().neighbours.bottomLeft = GetHex(i - 1, j + 1);
            }
        }
    }

    public GameObject GetHex(int i, int j)
    {
        if (i >= 0 && j >= 0 && i < 50 && j < 50)
        {
            return hexagons[i, j];
        }
        else
        {
            return null;
        }
    }
}
