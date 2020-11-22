using Assets.Save;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfacePanel : MonoBehaviour
{
    public GameObject notificationWindow;
    public GameObject MenuButton;
    public GameObject QuitButton;
    public TextMeshProUGUI notificationText;
    public ColorButtons ColorButtons;

    public void NewTurn(Player player)
    {
        notificationText.text = player.playerName + "'s Turn";
        notificationText.color = player.color;
    }

    public void GameEnded(Player player)
    {
        FindObjectOfType<ColorButtons>().gameObject.SetActive(false);
        QuitButton.SetActive(true);
        MenuButton.SetActive(false);
        notificationText.text = player.playerName + " won!";
        notificationText.color = player.color;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Save()
    {
        var dateTime = DateTime.Now.ToString("yyyyMMddHmmss");

        var sceneName = SceneManager.GetActiveScene().name;

        var hexmap = FindObjectOfType<GameController>().hexmap;

        var save = CreateSavegameObject(hexmap);

        string json = JsonUtility.ToJson(save);

        var currentDirectory = Directory.GetCurrentDirectory();

        var fileName = sceneName + dateTime + ".save";

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(currentDirectory, fileName)))
        {
            outputFile.WriteLine(json);
        }
    }

    private SaveModel CreateSavegameObject(Hexmap hexmap)
    {
        var saveObject = new SaveModel
        {
            SaveModels = new List<HexagonModel>(),
            SceneName = SceneManager.GetActiveScene().name,
            SaveTime = DateTime.Now, 
            ActiveAis = PlayerSettings.activeAis,
            ActivePlayers = PlayerSettings.activePlayers,
            AiLevel = PlayerSettings.aiLevel,
            Names = new List<string>(PlayerSettings.names),
            ActivePlayer = FindObjectOfType<GameController>().GetPlayer().id,
            Turn = FindObjectOfType<GameController>().GetTurn()
        };

        foreach (var hexagon in hexmap.hexagons)
        {
            saveObject.SaveModels.Add(new HexagonModel
            {
                Color = hexagon.GetMaterial().color,
                Player = hexagon.GetPlayer()
            });
        }

        return saveObject;

    }
}
