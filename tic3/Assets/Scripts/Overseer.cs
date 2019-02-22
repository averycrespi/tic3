using System;
using UnityEngine;

public class Overseer : MonoBehaviour
{
    public static Overseer instance = null;

    public GameObject board;
    public Material normal;
    public Material normalBlue;
    public Material normalRed;

    private BoardController controller;
    private bool isRedTurn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        controller = board.GetComponent<BoardController>();
        controller.InitializeBoard();
        isRedTurn = true;
    }

    public void HandleClick(string name)
    {
        string[] parts = name.Split(',');
        int superIndex = int.Parse(parts[0]);
        int subIndex = int.Parse(parts[1]);

        Material m = isRedTurn ? normalRed : normalBlue;
        if (controller.Play(superIndex, subIndex, m)) {
            isRedTurn = !isRedTurn;
            //TODO: check for game over
        }
    }
}
