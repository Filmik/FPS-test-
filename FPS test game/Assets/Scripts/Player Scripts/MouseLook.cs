using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float mouseSensitivity = 100f;
    [SerializeField]
    float clampYMin = -90;
    [SerializeField]
    float clampYMax = 90;
    float xRotation;
    Transform playerTransform;
    void Awake()=> playerTransform = transform;
    
    public void CameraMove(Vector2 mousePos)
    {
        float mouseX = mousePos.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mousePos.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, clampYMin, clampYMax);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
