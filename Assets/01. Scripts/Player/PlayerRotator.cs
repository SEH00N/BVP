using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Vector2 headRotateClamp;

    public void HeadRotateTo(float value)
    {
        Vector3 rotate = head.localEulerAngles;
        rotate.x = rotate.x >= 180f ? rotate.x - 360f : rotate.x;
        rotate.x -= value;

        rotate.x = Mathf.Clamp(rotate.x, headRotateClamp.x, headRotateClamp.y);
        head.localRotation = Quaternion.Euler(rotate);
    }

    public void BodyRotateTo(float value)
    {
        Vector3 bodyRotate = transform.localEulerAngles;
        bodyRotate.y += value;
        transform.localRotation = Quaternion.Euler(bodyRotate);    
    }
}
