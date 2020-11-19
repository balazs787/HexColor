using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfacePanel : MonoBehaviour
{
    public GameObject notificationWindow;
    public GameObject MenuButton;
    public GameObject QuitButton;
    public TextMeshProUGUI notificationText;

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
}
