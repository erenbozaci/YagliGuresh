using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Takip edilecek oyuncu (Player)
    public float smoothSpeed = 0.125f;  // Takip yumuþaklýðý (0.01 - 1 arasýnda önerilir)
    public Vector3 offset;              // Kamera ile oyuncu arasýndaki mesafe (örn. z: -10)

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: No target assigned!");
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
