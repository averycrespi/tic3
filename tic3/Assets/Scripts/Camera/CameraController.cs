using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orbit;
    public Transform target;

    private void Start()
    {
        orbit.position = target.position;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.LookAt(target.position);
    }
}
