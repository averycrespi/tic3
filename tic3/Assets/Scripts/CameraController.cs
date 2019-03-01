using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform orbit;
    public Transform target;

    public const int cameraDistance = 50;
    public const float rotateSpeed = 25f;
    public const float autoRotateSpeed = 10f;
    public const float scrollFactor = 0.025f;

    private bool autoRotate = false;

    private void Start()
    {
        orbit.position = target.position;
        cam.position = new Vector3(
            target.position.x + cameraDistance,
            target.position.y + cameraDistance,
            target.position.z
        );
        cam.LookAt(target.position);
    }

    private void Update()
    {
        AutoRotate();
        Yaw();
        Pitch();
        Zoom();
    }

    private void AutoRotate()
    {
        if (Input.GetKeyUp("space"))
        {
            autoRotate = !autoRotate;
        }
        if (autoRotate)
        {
            orbit.Rotate(Vector3.up * Time.deltaTime * autoRotateSpeed, Space.World);
        }
    }

    private void Yaw()
    {
        if (Input.GetKey("a"))
        {
            orbit.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
        }
        if (Input.GetKey("d"))
        {
            orbit.Rotate(Vector3.down * Time.deltaTime * rotateSpeed, Space.World);
        }
    }

    private void Pitch()
    {
        if (Input.GetKey("q"))
        {
            orbit.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed, Space.World);
        }
        if (Input.GetKey("e"))
        {
            orbit.Rotate(Vector3.back * Time.deltaTime * rotateSpeed, Space.World);
        }
    }

    private void Zoom()
    {
        if (Input.GetKey("w"))
        {
            orbit.localScale = orbit.localScale * (1f - scrollFactor);
        }
        if (Input.GetKey("s"))
        {
            orbit.localScale = orbit.localScale * (1f + scrollFactor);
        }
    }
}