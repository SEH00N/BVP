using UnityEngine;

[CreateAssetMenu(menuName = "SO/MovementSO")]
public class MovementSO : ScriptableObject
{
    [Range(0f, 30f)] public float inAccel;
    [Range(0f, 30f)] public float deAccel;
    [Range(0f, 30f)] public float maxSpeed;
}
