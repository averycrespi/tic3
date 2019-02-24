using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetController : MonoBehaviour
{
    private const float holdSpan = 3f;
    private float holdTime = 0;

    private void Update()
    {
        if (Input.GetKey("r"))
        {
            holdTime += Time.deltaTime;
            if (holdTime >= holdSpan)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
        else
        {
            holdTime = 0;
        }
    }
}
