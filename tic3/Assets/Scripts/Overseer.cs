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

    public void HandleClick(GameObject cube)
    {
        controller.HideAllExcept(0);
    }
}
