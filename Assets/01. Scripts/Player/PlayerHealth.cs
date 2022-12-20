using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHp = 100f;
    private float currentHp = 0f;

    public float CurrentHp { get => currentHp; set => currentHp = Mathf.Clamp(value, 0, maxHp); }
    public float MaxhHp => maxHp;

    private Player player = null;

    private Image sliderImage = null;
    private TextMeshProUGUI infoText = null;

    private void Awake()
    {
        player = GetComponent<Player>();

        Transform hpBarBackground = DEFINE.MainCanvas.Find("HPBar/Background");
        sliderImage = hpBarBackground.Find("Slider").GetComponent<Image>();
        infoText = hpBarBackground.Find("HpInfo").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        CurrentHp = maxHp;
        
        SetUI();
    }

    public void OnDamage(float damage, Vector3 hitPos = default, Action callback = null)
    {
        CurrentHp -= damage;
        SetUI();

        if (CurrentHp <= 0f)
        {
            Die();
        }
        else
        {
            player.Anim.SetTrigger("OnDamage");
        }
    }

    private void Die()
    {
        Debug.Log("죽었다 머저리야");
        //죽었다 머저리야
    }

    private void SetUI()
    {
        sliderImage.fillAmount = CurrentHp / maxHp;
        infoText.text = $"{CurrentHp}/{maxHp}";
    }
}