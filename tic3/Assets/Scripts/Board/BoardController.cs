using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Transform board;

    public float subCubeGap = 1f;
    public float superCubeGap = 3f;

    private float subCubeSize = 1f;
    private GameObject cubePrefab;
    private List<List<GameObject>> cubes;

    public void InitializeBoard()
    {
        Debug.Log("Initializing board");
        cubePrefab = Resources.Load<GameObject>("Prefabs/Cube");
        cubes = CreateSuperCubes();
    }

    List<List<GameObject>> CreateSuperCubes()
    {
        List<List<GameObject>> superCubes = new List<List<GameObject>>();
        float superCubeDistance = (3 * (subCubeSize + subCubeGap)) + superCubeGap;
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                for (int z = -1; z < 2; z++)
                {
                    Vector3 position = new Vector3(x * superCubeDistance, y * superCubeDistance, z * superCubeDistance);
                    superCubes.Add(CreateSubCubes(position));
                }
            }
        }
        return superCubes;
    }

    List<GameObject> CreateSubCubes(Vector3 cubePosition)
    {
        List<GameObject> subCubes = new List<GameObject>();
        float subCubeDistance = subCubeSize + subCubeGap;
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
                    subCubes.Add(subCube);
                }
            }
        }
        return subCubes;
    }
}
