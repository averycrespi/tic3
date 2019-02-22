using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetButtonController : MonoBehaviour
{
    public Button resetButton;

    private void Start()
    {
        resetButton.onClick.AddListener(ResetGame);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
