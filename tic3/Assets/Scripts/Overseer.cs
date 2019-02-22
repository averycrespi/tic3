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

    public void HandleClick(string name)
    {
        string[] parts = name.Split(',');
        int superIndex = int.Parse(parts[0]);
        int subIndex = int.Parse(parts[1]);

        if ((legalIndex == -1 || superIndex == legalIndex) && controller.HasMaterial(superIndex, subIndex, normal))
        {
            Material m = isRedTurn ? normalRed : normalBlue;
            controller.SetMaterial(superIndex, subIndex, m);
            isRedTurn = !isRedTurn;

            //TODO: completion checks

            legalIndex = controller.IsFull(superIndex) ? -1 : subIndex;
            controller.Show(legalIndex);
        }
    }
}
