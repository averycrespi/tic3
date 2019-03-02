using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform orbit;
    public Transform target;

    public const int cameraDistance = 50;
    public const float rotateSpeed = 40f;
    public const float idleSpeed = 10f;
    public const float scrollFactor = 0.025f;

    private bool idle = false;
    private bool invert = false;

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
        Idle();
        Orient();
        Rotate();
        Zoom();
    }

    private void Idle()
    {
        if (Input.GetKeyUp("space"))
        {
            idle = !idle;
        }
        if (idle)
        {
            orbit.Rotate(Vector3.up * Time.deltaTime * idleSpeed, Space.World);
        }
    }

    private void Orient()
    {
        if (Input.GetKeyUp("e"))
        {
            invert = !invert;
            float dist = invert ? -cameraDistance : cameraDistance;
            cam.position = new Vector3(
                target.position.x + dist,
                target.position.y + dist,
                target.position.z
            );
            cam.LookAt(target.position);
        }
    }

    private void Rotate()
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