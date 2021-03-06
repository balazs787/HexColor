﻿using Assets.Load;
using Assets.Save;
using Assets.Scripts.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject LoadElement;
    public GameObject LoadContent;
    public List<SaveModel> SaveModels;

    public TMP_InputField NoPlayers;
    public TMP_InputField NoAis;
    public TextMeshProUGUI AiLevel;

    public TextMeshProUGUI PlayerOneName;
    public TextMeshProUGUI PlayerTwoName;
    public TextMeshProUGUI PlayerThreeName;
    public TextMeshProUGUI PlayerFourName;

    private int currentEdit;

    public void SetCurrentEdit(int edit)
    {
        currentEdit = edit;
    }

    public void Start()
    {
        SaveModels = new List<SaveModel>();
    }

    public void SetNumberOfPlayers(TMP_InputField input)
    {
        var number = int.Parse(input.text);

        if (number < 2)
        {
            number = 2;
        }
        else if (number > 4)
        {
            number = 4;
        }
        input.text = number.ToString();
        PlayerSettings.activePlayers = number;
    }

    public void SetNumberOfAis(TMP_InputField input)
    {
        var number = int.Parse(input.text);

        if (number < 0)
        {
            number = 0;
        }
        else if (number > PlayerSettings.activePlayers)
        {
            number = PlayerSettings.activePlayers;
        }
        input.text = number.ToString();
        PlayerSettings.activeAis = number;
    }

    public void SetName(TextMeshProUGUI name)
    {
        PlayerSettings.names[currentEdit] = name.text;
    }

    public void SetAiLevel(int level)
    {
        PlayerSettings.aiLevel = level;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PopulateList()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var filePaths = Directory.GetFiles(currentDirectory, "*.save", SearchOption.TopDirectoryOnly);

        SaveModels.Clear();

        foreach (var path in filePaths)
        {
            using (var sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();

                var loadModel = JsonUtility.FromJson<SaveModel>(json);

                SaveModels.Add(loadModel);
            }
        }

        var index = 0;

        foreach (var model in SaveModels)
        {
            var loadPrefab = Instantiate(LoadElement, LoadContent.transform);
            loadPrefab.GetComponent<LoadElement>().Setup(model.SceneName, model.SaveTime, index++);
        }
    }

    public void LoadSettings()
    {
        NoPlayers.text = PlayerSettings.activePlayers.ToString();
        NoAis.text = PlayerSettings.activeAis.ToString();

        var ailevel = PlayerSettings.aiLevel;
        if (ailevel==1)
        {
            AiLevel.text = "Medium";
        }else if(ailevel == 2)
        {
            AiLevel.text = "Hard";
        }

        PlayerOneName.text = PlayerSettings.names[0];
        PlayerTwoName.text = PlayerSettings.names[1];
        PlayerThreeName.text = PlayerSettings.names[2];
        PlayerFourName.text = PlayerSettings.names[3];
    }

    public void ClearList()
    {
        foreach (Transform child in LoadContent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
