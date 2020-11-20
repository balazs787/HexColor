using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float PanSpeed = 20f;
    public float PanBoundary = 15f;
    public float ScrollSpeed = 1000f;
    public float MinZoom = 5f;
    public float MaxZoom = 50f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Update()
    {
        var position = transform.position;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - PanBoundary)
        {
            position.z += PanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= PanBoundary)
        {
            position.z -= PanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= PanBoundary)
        {
            position.x -= PanSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - PanBoundary)
        {
            position.x += PanSpeed * Time.deltaTime;
        }

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y += -scroll * ScrollSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, MinZoom, MaxZoom);
        position.z = Mathf.Clamp(position.z, minY, maxY);

        transform.position = position;
    }
}
