using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Overseer overseer;

    void Start()
    {
        overseer = GameObject.Find("Overseer").GetComponent<Overseer>();
    }

    void OnMouseUp()
    {
        Debug.Log("Click on: " + gameObject.name);
        overseer.HandleClick(gameObject);
    }
}
