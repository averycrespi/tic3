using UnityEngine;

public class QuitController : MonoBehaviour
{
    private const float holdSpan = 3f;
    private float holdTime = 0;

    private void Update()
    {
        if (Input.GetKey("q"))
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdSpan)
            {
                Application.Quit();
            }
        }
        else
        {
            holdTime = 0;
        }
    }
}
