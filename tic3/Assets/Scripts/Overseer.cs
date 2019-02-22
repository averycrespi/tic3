using System;
using UnityEngine;

public class Overseer : MonoBehaviour
{
    public static Overseer instance = null;
    public GameObject board;
    public Material normalRed;

    private BoardController controller;
    private int legalIndex;

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

        if (legalIndex == -1 || superIndex == legalIndex)
        {
            controller.SetCubeMaterial(superIndex, subIndex, normalRed);

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
