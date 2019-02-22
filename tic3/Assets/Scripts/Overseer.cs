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
        Debug.Log("Handing click: super=" + indexes.Item1.ToString() + ", sub=" + indexes.Item2.ToString());

        if (legalIndex == -1 || indexes.Item1 == legalIndex)
        {
            controller.SetCubeMaterial(indexes.Item1, indexes.Item2, normalRed);

            if (controller.IsFull(indexes.Item2))
            {  
                controller.UnhideAll();
                legalIndex = -1;
            }
            else
            {
                controller.HideAllExcept(indexes.Item2);
                legalIndex = indexes.Item2;
            }
        }
    }
}
