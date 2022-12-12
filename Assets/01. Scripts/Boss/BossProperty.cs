using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProperty : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] float groggyPercentage = 0f;
    public float GroggyPercentage {
        get => groggyPercentage;
        set => groggyPercentage = Mathf.Clamp(value, 0f, 1f);
    }
}
