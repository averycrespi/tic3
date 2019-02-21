using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Transform board;

    public float cubeSize = 1f;
    public float cubeGap = 0.5f;

    private GameObject cube;
    private List<GameObject> cubes;

    void Start()
    {
        cube = Resources.Load<GameObject>("Prefabs/Cube");
        cubes = new List<GameObject>();
        float distance = cubeSize + cubeGap;
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                for (int z = -1; z < 2; z++)
                {
                    GameObject c = Instantiate(cube, new Vector3(x * distance, y * distance, z * distance), Quaternion.identity);
                    c.transform.parent = board;
                    cubes.Add(c);
                }
            }
        }
    }
}
