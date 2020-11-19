using UnityEngine;
using UnityEngine.UI;

public class ColorButtons : MonoBehaviour
{
    public Material[] materials;
    private Button _lastChoice;

    public void Deactive(Button button)
    {
        foreach (var b in GetComponentsInChildren<Button>())
        {
            b.interactable = true;
        }
        button.interactable = false;
        if (_lastChoice != null)
        {
            _lastChoice.interactable = false;
        }
        _lastChoice = button;
    }

    public void PaintColor(int color)
    {
        FindObjectOfType<GameController>().GetPlayer().ChooseColor(materials[color]);
        FindObjectOfType<GameController>().NextPlayer();
    }
}
