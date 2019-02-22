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
    private bool redTurn;

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

        Debug.Log("Starting overseer");
        controller = board.GetComponent<BoardController>();
        controller.InitializeBoard();
        legalIndex = -1;
        redTurn = true;
    }

    Tuple<int, int> ParseName(string name)
    {
        //TODO: handle errors
        string[] parts = name.Split(',');
        return new Tuple<int, int>(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    public void HandleClick(GameObject cube)
    {
        Tuple<int, int> indexes = ParseName(cube.name);
        int superIndex = indexes.Item1;
        int subIndex = indexes.Item2;
        Debug.Log("Handing click: superIndex=" + superIndex.ToString() + ", subIndex=" + subIndex.ToString());

        Material current = cube.GetComponent<Renderer>().sharedMaterial;
        if ((legalIndex == -1 || superIndex == legalIndex) && current == normal)
        {
            if (redTurn)
            {
                controller.SetCubeMaterial(superIndex, subIndex, normalRed);
                redTurn = false;
            }
            else
            {
                controller.SetCubeMaterial(superIndex, subIndex, normalBlue);
                redTurn = true;
            }

            if (controller.IsFull(subIndex))
            {  
                controller.UnhideAll();
                legalIndex = -1;
            }
            else
            {
                controller.HideAllExcept(subIndex);
                legalIndex = subIndex;
            }
        }
    }
}
