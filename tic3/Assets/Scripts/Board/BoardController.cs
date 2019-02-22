using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Transform board;
    public Material normal;
    public Material normalBlue;
    public Material normalRed;
    public Material hidden;
    public Material hiddenBlue;
    public Material hiddenRed;

    public float subCubeGap = 2f;
    public float superCubeGap = 6f;

    private const int anywhereIndex = -1;
    private const int fullStatus = 27;
    private const int redWon = 1;
    private const int blueWon = 2;
    private const float subCubeSize = 1f;
    private bool isGameOver;
    private bool isFirstMove;
    private int currentIndex;
    private GameObject prefab;
    private List<List<GameObject>> cubes;
    private List<int> cubeStatus;
    private List<int> cubeWinner;

    private List<List<GameObject>> CreateSuperCubes()
    {
        List<List<GameObject>> superCubes = new List<List<GameObject>>();
        float superCubeDistance = (3 * (subCubeSize + subCubeGap)) + superCubeGap;
        int superIndex = 0;
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                for (int z = -1; z < 2; z++)
                {
                    Vector3 position = new Vector3(x * superCubeDistance, y * superCubeDistance, z * superCubeDistance);
                    superCubes.Add(CreateSubCubes(position, superIndex));
                    superIndex++;
                }
            }
        }
        return superCubes;
    }

    private List<GameObject> CreateSubCubes(Vector3 cubePosition, int superIndex)
    {
        List<GameObject> subCubes = new List<GameObject>();
        float subCubeDistance = subCubeSize + subCubeGap;
        int subIndex = 0;
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                for (int z = -1; z < 2; z++)
                {
                    Vector3 position = new Vector3(cubePosition.x + (x * subCubeDistance), cubePosition.y + (y * subCubeDistance), cubePosition.z + (z * subCubeDistance));
                    GameObject subCube = Instantiate(prefab, position, Quaternion.identity);
                    subCube.transform.localScale = new Vector3(subCubeSize, subCubeSize, subCubeSize);
                    subCube.transform.parent = board;
                    subCube.name = superIndex.ToString() + "," + subIndex.ToString();
                    subCube.GetComponent<Renderer>().material = normal;
                    subCubes.Add(subCube);
                    subIndex++;
                }
            }
        }
        return subCubes;
    }

    private void Show(int superIndex)
    {
        foreach(GameObject sub in cubes[superIndex])
        {
            Renderer r = sub.GetComponent<Renderer>();
            if (r.sharedMaterial == normalBlue || r.sharedMaterial == hiddenBlue)
            {
                r.material = normalBlue;
            }
            else if (r.sharedMaterial == normalRed || r.sharedMaterial == hiddenRed)
            {
                r.material = normalRed;
            }
            else
            {
                r.material = normal;
            }
        }
    }

    private void Hide(int superIndex)
    {
        foreach (GameObject sub in cubes[superIndex])
        {
            Renderer r = sub.GetComponent<Renderer>();
            if (r.sharedMaterial == normalBlue || r.sharedMaterial == hiddenBlue)
            {
                r.material = hiddenBlue;
            }
            else if (r.sharedMaterial == normalRed || r.sharedMaterial == hiddenRed)
            {
                r.material = hiddenRed;
            }
            else
            {
                r.material = hidden;
            }
        }
    }

    private void Render()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            if (cubeStatus[i] == fullStatus || (isFirstMove && i == 13))
            {
                Hide(i);
            }
            else if (currentIndex == i || currentIndex == anywhereIndex)
            {
                Show(i);
            }
            else
            {
                Hide(i);
            }
        }
    }

    private bool IsSuperWon(int superIndex)
    {
        List<GameObject> subs = cubes[superIndex];
        foreach (Tuple<int, int, int> winSet in BoardHelper.winSets)
        {
            Material m1 = subs[winSet.Item1].GetComponent<Renderer>().sharedMaterial;
            Material m2 = subs[winSet.Item2].GetComponent<Renderer>().sharedMaterial;
            Material m3 = subs[winSet.Item3].GetComponent<Renderer>().sharedMaterial;
            if (m1 != normal && m1 == m2 && m2 == m3)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsBoardWon()
    {
        foreach (Tuple<int, int, int> winSet in BoardHelper.winSets)
        {
            int w1 = cubeWinner[winSet.Item1];
            int w2 = cubeWinner[winSet.Item2];
            int w3 = cubeWinner[winSet.Item3];
            if (w1 != 0 && w1 == w2 && w2 == w3)
            {
                return true;
            }
        }
        return false;
    }

    private void Fill(int superIndex, Material m)
    {
        foreach(GameObject sub in cubes[superIndex])
        {
            sub.GetComponent<Renderer>().material = m;
        }
    }

    public bool Play(int superIndex, int subIndex, Material m)
    {
        Renderer target = cubes[superIndex][subIndex].GetComponent<Renderer>();
        if ((currentIndex == superIndex || currentIndex == anywhereIndex) && target.sharedMaterial == normal)
        {
            target.material = m;
            cubeStatus[superIndex]++;
            if (IsSuperWon(superIndex))
            {
                Fill(superIndex, m);
                cubeStatus[superIndex] = fullStatus;
                cubeWinner[superIndex] = (m == normalRed) ? redWon : blueWon;
            }
            if (IsBoardWon())
            {
                for (int i = 0; i < cubes.Count; i++)
                {
                    Fill(i, m);
                    cubeStatus[i] = fullStatus;
                    cubeWinner[i] = (m == normalRed) ? redWon : blueWon;
                }
                isGameOver = true;
            }
            currentIndex = (cubeStatus[subIndex] == fullStatus) ? anywhereIndex : subIndex;
            isFirstMove = false;
            Render();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void InitializeBoard()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Cube");
        cubes = CreateSuperCubes();
        cubeStatus = new List<int>(new int[cubes.Count]);
        cubeWinner = new List<int>(new int[cubes.Count]);
        currentIndex = anywhereIndex;
        isGameOver = false;
        isFirstMove = true;
        Render();
    }
}
