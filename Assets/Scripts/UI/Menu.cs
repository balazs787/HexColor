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

    public void SetName(TextMeshProUGUI name)
    {
        PlayerSettings.names[currentEdit] = name.text;
    }

    public void SetAi(Toggle toggle)
    {
        PlayerSettings.ais[currentEdit] = toggle.isOn;
    }

    public void SetAiLevel(InputField input)
    {
        PlayerSettings.aiLevel[currentEdit] = int.Parse(input.text);
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
