using System;
using UnityEngine;

public class Core : MonoBehaviour, IDamageable
{
    public Color currentColor = Color.gray;
    private Material coreMaterial = null;

    [SerializeField] float maxHp = 100f;
    [SerializeField] float currentHp = 0f;

    public float CurrentHp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public float MaxhHp => throw new NotImplementedException();

    private void Awake()
    {
        coreMaterial = GetComponent<MeshRenderer>().material;
    }

    public void OnDamage(float damage, Vector3 hitPos = default, Action callback = null)
    {
        currentHp -= damage;
        Debug.LogWarning("아얏");

        if(currentHp <= 0f)
            OnDie();
    }

    private void OnDie()
    {
        //엔딩
    }

    public void SetColor(Color targetColor)
    {
        currentColor = targetColor;
        coreMaterial.SetColor("_Color", currentColor);
    }
}
