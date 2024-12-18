using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHpGauge : MonoBehaviour, IGauge
{
    [SerializeField] private Image hpFillImage;
    [SerializeField] private TextMeshProUGUI hpText;
    public void UpdateGauge(float currentValue, float maxValue)
    {
        if (hpFillImage != null)
        {
            hpFillImage.fillAmount = currentValue / maxValue;
        }
        if (hpText != null)
        {
            hpText.text = Mathf.Ceil(currentValue).ToString();
        }

    }
    public void SetVisibility(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }


}
