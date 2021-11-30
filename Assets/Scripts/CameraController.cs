using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    void Start() {

    }

    private void LateUpdate() {
        Vector3 temp = transform.position;
        if (playerTransform.position.x > -36 && playerTransform.position.x < 36) {
            temp.x = playerTransform.position.x;
            transform.position = temp;
        }
    }
}
