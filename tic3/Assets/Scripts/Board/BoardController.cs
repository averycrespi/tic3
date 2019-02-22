using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Transform board;
    public Material normal;
    public Material hidden;

    public float subCubeGap = 1f;
    public float superCubeGap = 3f;

    private float subCubeSize = 1f;
    private GameObject cubePrefab;
    private List<List<GameObject>> cubes;

    List<List<GameObject>> CreateSuperCubes()
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

    List<GameObject> CreateSubCubes(Vector3 cubePosition, int superIndex)
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
                    GameObject subCube = Instantiate(cubePrefab, position, Quaternion.identity);
                    subCube.transform.localScale = new Vector3(subCubeSize, subCubeSize, subCubeSize);
                    subCube.transform.parent = board;
                    subCube.name = superIndex.ToString() + "," + subIndex.ToString();
                    subCubes.Add(subCube);
                    subIndex++;
                }
            }
        }
        return subCubes;
    }

    public void InitializeBoard()
    {
        Debug.Log("Initializing board");
        cubePrefab = Resources.Load<GameObject>("Prefabs/Cube");
        cubes = CreateSuperCubes();
    }

    public void UnhideAll()
    {
        Debug.Log("Unhiding all cubes");
        foreach (List<GameObject> super in cubes)
        {
            foreach (GameObject sub in super)
            {
                Renderer rend = sub.GetComponent<Renderer>();
                rend.material = normal;
            }
        }
    }

    public void HideAllExcept(int index)
    {
        Debug.Log("Hiding all cubes except: " + index.ToString());
        for (int i = 0; i < cubes.Count; i++)
        {
            if (i != index)
            {
                foreach (GameObject sub in cubes[i])
                {
                    Renderer rend = sub.GetComponent<Renderer>();
                    rend.material = hidden;
                }
            }
        }
    }
}
