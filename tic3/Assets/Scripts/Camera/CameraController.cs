using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orbit;
    public Transform target;

    void Start()
    {
        orbit.position = target.position;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.LookAt(target.position);
    }
}
