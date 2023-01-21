using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Core : MonoBehaviour, IDamageable
{
    public Color currentColor = Color.gray;
    private Material coreMaterial = null;

    [SerializeField] float maxHp = 100f;
    [SerializeField] float currentHp = 0f;

    [SerializeField] Image endImage = null;

    public float CurrentHp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public float MaxhHp => throw new NotImplementedException();

    private void Awake()
    {
        coreMaterial = GetComponent<MeshRenderer>().material;

        currentHp = maxHp;
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
        TimeManager.Instance.Stop();
        Time.timeScale = 0f;
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        seq.Append(endImage.DOFade(1, 3f).SetEase(Ease.Linear));
        seq.AppendCallback(() => SceneLoader.Instance.LoadAsync("End"));
    }

    public void SetColor(Color targetColor)
    {
        coreMaterial = GetComponent<MeshRenderer>().material;
        currentColor = targetColor;
        coreMaterial.SetColor("_Color", currentColor);
    }
}
