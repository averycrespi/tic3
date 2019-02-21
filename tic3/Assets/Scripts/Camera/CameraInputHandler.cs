using UnityEngine;

public class CameraInputHandler : MonoBehaviour
{
    public GameObject orbit;

    public float rotateSpeed = 2f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float h = rotateSpeed * Input.GetAxis("Mouse X");
            float v = rotateSpeed * Input.GetAxis("Mouse Y");

            if (orbit.transform.eulerAngles.z + v <= 0.1f || orbit.transform.eulerAngles.z + v >= 179.9f)
            {
                v = 0;
            }

            orbit.transform.eulerAngles = new Vector3(
                orbit.transform.eulerAngles.x,
                orbit.transform.eulerAngles.y + h,
                orbit.transform.eulerAngles.z + v
            );
        }

        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");
        if (scrollFactor != 0)
        {
            orbit.transform.localScale = orbit.transform.localScale * (1f - scrollFactor);
        }
    }
}
