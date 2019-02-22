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
    private int legalIndex;
    private bool isRedTurn;

    void Awake()
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
        legalIndex = -1;
        isRedTurn = true;
    }

    Tuple<int, int> ParseName(string name)
    {
        string[] parts = name.Split(',');
        return new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    void TakeTurn(int superIndex, int subIndex)
    {
        Material m = isRedTurn ? normalRed : normalBlue;
        controller.SetCubeMaterial(superIndex, subIndex, m);
        isRedTurn = !isRedTurn;
    }
  
    void AdvanceBoard(int superIndex)
    {
        if (controller.IsFull(superIndex))
        {
            controller.UnhideAll();
            legalIndex = -1;
        }
        else
        {
            controller.HideAllExcept(superIndex);
            legalIndex = superIndex;
        }
    }

    public void HandleClick(GameObject cube)
    {
        Tuple<int, int> indexes = ParseName(cube.name);
        int superIndex = indexes.Item1;
        int subIndex = indexes.Item2;

        Material current = cube.GetComponent<Renderer>().sharedMaterial;
        if ((legalIndex == -1 || superIndex == legalIndex) && current == normal)
        {
            TakeTurn(superIndex, subIndex);
            AdvanceBoard(subIndex);
        }
    }
}
