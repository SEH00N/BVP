using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Vector2 headRotateClamp;

    public void RotateTo(Vector2 dir)
    {
        Vector3 bodyRotate = transform.localEulerAngles;
        bodyRotate.y += dir.y;
        transform.localRotation = Quaternion.Euler(bodyRotate);

        Vector3 headRotate = head.localEulerAngles;
        headRotate.x = headRotate.x >= 180f ? headRotate.x - 360f : headRotate.x;
        headRotate.x -= dir.x;
    
        headRotate.x = Mathf.Clamp(headRotate.x, headRotateClamp.x, headRotateClamp.y);
        head.localRotation = Quaternion.Euler(headRotate);
    }
}
