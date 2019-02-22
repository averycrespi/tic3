using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardHelper : MonoBehaviour
{
    public static List<Tuple<int, int, int>> winSets;

    private void Start()
    {
        List<int> additives = new List<int>();

        // Left -> right
        additives.Add(3);

        // Front -> back
        additives.Add(1);

        // Bottom -> top
        additives.Add(9);

        // Back left -> front right
        additives.Add(2);

        // Front left -> back right
        additives.Add(4);

        // Bottom left -> top right
        additives.Add(12);

        // Bottom front -> top back
        additives.Add(10);

        // Bottom back left -> top front right
        additives.Add(11);

        // Bottom front left -> top back right
        additives.Add(13);

        winSets = new List<Tuple<int, int, int>>();
        foreach (int additive in additives)
        {
            for (int i = 0; i < 26; i++)
            {
                if (i + (additive * 2) <= 26)
                {
                    winSets.Add(new Tuple<int, int, int>(i, i + additive, i + (additive * 2)));
                }
            }
        }
    }
}
