using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardHelper : MonoBehaviour
{
    public static List<Tuple<int, int, int>> winSets;

    private void Start()
    {
        /*
         * Layout:
         * 
         * 20   19  18
         * 11   10  9
         * 2    1   0
         * 
         * 23   22  21
         * 14   13  12
         * 5    4   3
         * 
         * 26   25  24
         * 17   16  15
         * 8    7   6
         * 
         * Additives:
         * 
         * Right        -> left         = 1
         * Front        -> back         = 9
         * Bottom       -> top          = 3
         * 
         * Left front   -> right back   = 8
         * Right front  -> left back    = 10
         * 
         * Left bottom  -> Right top    = 2
         * Right bottom -> Left top     = 4
         * 
         * Front bottom -> Back top     = 12
         * Back bottom  -> Front top    = 6
         * 
         * Left back bottom -> Right front top = 7
         * Right back bottom -> Left front top = 5
         * Left front bottom -> Right back top = 11
         * Right front bottom -> Left back top = 13
         */

        winSets = new List<Tuple<int, int, int>>();
        for (int a = 1; a < 14; a++)
        {
            for (int i = 0; i < 26; i++)
            {
                if (i + (a * 2) <= 26)
                {
                    winSets.Add(new Tuple<int, int, int>(i, i + a, i + (a * 2)));
                }
            }
        }
    }
}
