using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // https://www.youtube.com/watch?v=Tz-2Z0vLLt8
    [SerializeField] float mouseSensitivity = 250f;

    [SerializeField] float maxViewDistance = -20f;
    [SerializeField] float minViewDistance = 80f;

    [SerializeField] Transform cameraTransf;

    private float xRotation = 0f;
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        // capture la souris ???
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        OldInput_Look();

        // mouvement camera vertical
        xRotation -= mouseY;
        // Clamp give a value between min and max, replace a if statement
        xRotation = Mathf.Clamp(xRotation, maxViewDistance, minViewDistance);
        cameraTransf.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // mouvement horizontal G/D
        transform.Rotate(Vector3.up * mouseX);
    }

    void OldInput_Look()
    {
        // The movement is managed with the old input system, axe Y horizon, axe X vertical
        mouseX = mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse X");
        mouseY = mouseSensitivity * Time.deltaTime * Input.GetAxis("Mouse Y");
    }

    void OnCameraLook(Vector2 v)
    {
        mouseX = v.x;
        mouseY = v.y;
    }
}