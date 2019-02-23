using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
    public Button helpButton;

    private const int windowWidth = 300;
    private const int windowHeight = 220;
    private const int itemHeight = 20;
    private const int itemOffset = 25;
    private Rect confirmRect;
    private bool show;

    private void Start()
    {
        helpButton.onClick.AddListener(ShowHelp);
        confirmRect = new Rect(Screen.width - windowWidth - 10, Screen.height - windowHeight - 10, windowWidth, windowHeight);
        show = false;
    }

    private void ShowHelp()
    {
        show = true;
    }

    private void OnGUI()
    {
        if (show)
        {
            confirmRect = GUI.Window(1, confirmRect, DialogWindow, "Help");
        }
    }

    private void DialogWindow(int windowID)
    {
        GUI.Label(new Rect(5, itemOffset, confirmRect.width - 10, itemHeight), "Click on a cube to make a move");
        GUI.Label(new Rect(5, itemOffset * 2, confirmRect.width - 10, itemHeight), "Click and drag to rotate the camers");
        GUI.Label(new Rect(5, itemOffset * 3, confirmRect.width - 10, itemHeight), "Scroll to zoom in or out");
        GUI.Label(new Rect(5, itemOffset * 4, confirmRect.width - 10, itemHeight), "Press space to toggle automatic camera rotation");
        GUI.Label(new Rect(5, itemOffset * 5, confirmRect.width - 10, itemHeight), "Press M to toggle background music");
        GUI.Label(new Rect(5, itemOffset * 6, confirmRect.width - 10, itemHeight), "Press R to reset the game");
        GUI.Label(new Rect(5, itemOffset * 7, confirmRect.width - 10, itemHeight), "Press Q to quit the game");
        if (GUI.Button(new Rect(5, itemOffset * 8, confirmRect.width - 10, itemHeight), "Cancel"))
        {
            show = false;
        }
    }
}
