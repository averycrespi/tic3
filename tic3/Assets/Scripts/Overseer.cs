using System;
using UnityEngine;

public class Overseer : MonoBehaviour
{
    public static Overseer instance = null;

    public GameObject board;

    private BoardController controller;

    void Start()
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
    }
}
