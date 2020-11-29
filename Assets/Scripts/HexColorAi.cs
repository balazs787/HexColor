using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class HexColorAi : MonoBehaviour
    {
        public GameController gameController;

        //The count of hexagons that can be converted for each material
        public Dictionary<Color, int> AccessibleFields;

        private void Start()
        {
            AccessibleFields = new Dictionary<Color, int>() { };
            foreach (var material in gameController.interfacePanel.ColorButtons.materials)
            {
                AccessibleFields.Add(material.color, 0);
            }
        }

        public void AiTurn(Player player)
        {
            foreach (var hexagon in gameController.hexmap.hexagons)
            {
                if (hexagon.GetPlayer() == player)
                {
                    foreach (var neighbour in hexagon.GetNeighbours())
                    {
                        if (neighbour!=null && neighbour.GetPlayer() == null)
                        {
                            AccessibleFields[neighbour.GetMaterial().color]++;
                        }
                    }
                }
            }

            List<Material> possibleChoices = new List<Material>();
            Material bestChoice = null;
            foreach (var material in gameController.interfacePanel.ColorButtons.materials)
            {
                if (CheckAvailability(material))
                {
                    if (bestChoice == null)
                    {
                        bestChoice = material;
                    }
                    possibleChoices.Add(material);
                    if (AccessibleFields[material.color] >= AccessibleFields[bestChoice.color])
                    {
                        bestChoice = material;
                    }
                }
            }

            AiColorPick(bestChoice, possibleChoices);
            ClearAccessibleFields();
        }

        private void ClearAccessibleFields()
        {
            foreach (var material in gameController.interfacePanel.ColorButtons.materials)
            {
                AccessibleFields[material.color] = 0;
            }
        }

        public void AiColorPick(Material bestChoice, List<Material> possibleChoices)
        {
            if (PlayerSettings.aiLevel == 2)
            {
                gameController.interfacePanel.ColorButtons.PaintColor(bestChoice);
            }
            else
            {
                int r = UnityEngine.Random.Range(0, possibleChoices.Count);
                if (PlayerSettings.aiLevel == 1)
                {
                    if (r % 2 == 0)
                    {
                        gameController.interfacePanel.ColorButtons.PaintColor(bestChoice);
                    }
                    else
                    {
                        gameController.interfacePanel.ColorButtons.PaintColor(possibleChoices[r]);
                    }

                }
                else
                {
                    gameController.interfacePanel.ColorButtons.PaintColor(possibleChoices[r]);
                }
            }
        }

        public bool CheckAvailability(Material material)
        {
            foreach (var player in gameController.players)
            {
                if (player.color == material.color)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
