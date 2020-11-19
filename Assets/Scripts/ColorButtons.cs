using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButtons : MonoBehaviour
{
    public Material[] materials;
    public Button[] Buttons;

    public void Deactive(Button button)
    {
        foreach (var b in Buttons)
        {
            b.interactable = true;
        }
        for (int i = 0; i < materials.Length; i++)
        {
            foreach (var player in FindObjectOfType<GameController>().players)
            {
                if (player.color == materials[i].color)
                {
                    Buttons[i].interactable = false;
                }
            }
        }
    }

    public void PaintColor(int color)
    {
        FindObjectOfType<GameController>().GetPlayer().ChooseColor(materials[color]);
        FindObjectOfType<GameController>().NextPlayer();
    }
}
