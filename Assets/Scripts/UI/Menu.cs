using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject SettingsButton;
    public GameObject ConfrimSettingsButton;
    public GameObject SettingsPanel;
    public GameObject OptionsPanel;

    private int currentEdit;

    public void SetCurrentEdit(int edit)
    {
        currentEdit = edit;
    }

    public void SetNumberOfPlayers(TMP_InputField input)
    {
        var number = int.Parse(input.text);

        if (number < 2)
        {
            number = 2;
        }
        else if(number > 4)
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

    public void ChoosePlayerAndStart(int numberOfPlayers)
    {
        PlayerSettings.activePlayers = numberOfPlayers;
        SceneManager.LoadScene("Game");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
