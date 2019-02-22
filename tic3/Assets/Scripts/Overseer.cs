using UnityEngine;

public class Overseer : MonoBehaviour
{
    public GameObject board;

    private BoardController controller;

    void Start()
    {
        Debug.Log("Starting overseer");
        controller = board.GetComponent<BoardController>();
        controller.InitializeBoard();
    }
}
