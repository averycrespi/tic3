using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Overseer overseer;

    void Start()
    {
        overseer = GameObject.Find("Overseer").GetComponent<Overseer>();
    }

    void OnMouseUpAsButton()
    {
        overseer.HandleClick(gameObject.name);
    }
}
