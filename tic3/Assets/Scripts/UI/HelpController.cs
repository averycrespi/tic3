using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpController : MonoBehaviour
{
    public Button helpButton;
    public Font font;
    public const int fieldHeight = 25;
    public const int fieldOffset = 0;
    public const int windowWidth = 300;

    private int windowHeight;
    private List<string> fields;
    private Rect confirmRect;
    private bool show;

    private void Start()
    {
        helpButton.onClick.AddListener(
            () => {show = !show;}
        );
        fields = new List<string>(new string[]
        {
            "Use WASD to control the camera",
            "Press space to toggle idle mode",
            "Press E to toggle camera position",
            "Press M to toggle background music",
            "Hold R to reset",
            "Hold Q to quit"
        });
        windowHeight = (fieldHeight * fields.Count) + (fieldOffset * (fields.Count - 1));
        confirmRect = new Rect(Screen.width - windowWidth - 10, Screen.height - windowHeight - 10, windowWidth, windowHeight);
    }

    private void OnGUI()
    {
        if (show)
        {
            confirmRect = GUI.Window(1, confirmRect, DialogWindow, "");
            GUI.skin.font = font;
        }
    }

    private void DialogWindow(int windowID)
    {
        for (int i = 0; i < fields.Count; i++)
        {
            float y = (fieldHeight + fieldOffset) * i;
            GUI.Label(new Rect(5, y, confirmRect.width - 5, fieldHeight), fields[i]);
        }
    }
}
