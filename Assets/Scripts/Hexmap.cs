using System.Collections.Generic;
using UnityEngine;

public class Hexmap : MonoBehaviour
{
    public List<HexagonField> hexagons;
    public List<HexagonField> startingHexagons;

    public void Init()
    {
        foreach (var hexagon in FindObjectsOfType<HexagonField>())
        {
            hexagons.Add(hexagon);
        }

        foreach (var hexagon in hexagons)
        {
            hexagon.GetComponent<MeshRenderer>().material = (FindObjectOfType<ColorButtons>().materials[Random.Range(0, 10)]);
        }


        foreach (var hexagon in startingHexagons)
        {
            if (hexagon.GetPlayer() != null)
            {
                hexagon.GetComponent<MeshRenderer>().material.color = Color.black;
            }
        }
    }

    public void ResetAll()
    {
        foreach (var hex in hexagons)
        {
            hex.ResetChecked();
        }
    }
}
