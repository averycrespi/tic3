using UnityEngine;

public class QuitController : MonoBehaviour
{
    private const int windowWidth = 150;
    private const int windowHeight = 80;
    private const int itemHeight = 20;
    private const int itemOffset = 25;
    private Rect confirmRect;
    private bool show;

    private void Start()
    {
        confirmRect = new Rect((Screen.width - windowWidth) / 2, (Screen.height - windowHeight) / 2, windowWidth, windowHeight);
        show = false;
    }

    private void OnGUI()
    {
        if (show)
        {
            confirmRect = GUI.Window(0, confirmRect, DialogWindow, "Are you sure?");
        }
    }

    private void DialogWindow(int windowID)
    {
        if (GUI.Button(new Rect(5, itemOffset, confirmRect.width - 10, itemHeight), "Quit"))
        {
            Application.Quit();
            show = false;
        }
        if (GUI.Button(new Rect(5, itemOffset * 2, confirmRect.width - 10, itemHeight), "Cancel"))
        {
            show = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp("q") && !show)
        {
            show = true;
        }
    }
}
