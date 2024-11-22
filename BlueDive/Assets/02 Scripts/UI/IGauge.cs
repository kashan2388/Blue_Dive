using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGauge
{
    void UpdateGauge(float currentValue, float maxValue);
    void SetVisibility(bool isVisible);
}
