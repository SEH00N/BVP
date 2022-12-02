using UnityEngine;

[CreateAssetMenu(menuName = "SO/MovementSO")]
public class MovementSO : ScriptableObject
{
    [Range(0f, 30f)] public float inAccel;
    [Range(0f, 30f)] public float deAccel;
    [Range(0f, 30f)] public float maxSpeed;
    [Range(0f, 30f)] public float jumpSpeed;
    [Range(0, 5)] public int maxJumpCount;
    public Vector2 gravityClamp;
}
