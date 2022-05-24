using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SmoothBar : MonoBehaviour
{
    [Header("Bar System Variables")]
    [SerializeField] private Image barImage = null;
    [SerializeField] private bool startOnAwake = true;
    [SerializeField] private float barValue = 0;
    [SerializeField] private float maxBarValue = 100;
    [SerializeField] private float duration = 0.25f;
    
    [Space(20)]
    
    /// <summary>
    /// Returns the value of the bar value when the value of the bar changes
    /// </summary>
    public Action<float> OnBarValueChanged;
    
    /// <summary>
    /// Returns the value of the max bar value when the value of the max bar changes
    /// </summary>
    public Action<float> OnMaxBarValueChanged;
    
    /// <summary>
    /// Called when bar value change starts
    /// </summary>
    public Action OnBarValueChangeStart;
    
    /// <summary>
    /// Called when bar value change is finished
    /// </summary>
    public Action OnBarValueChangeEnd;

    private void Awake()
    {
        OnBarValueChanged += BarValueChange;
    }

    private void Start()
    {
        if (startOnAwake)
            StartSmoothBar();
    }

    private void OnDestroy()
    {
        OnBarValueChanged -= BarValueChange;
    }

    public void StartSmoothBar()
    {
        StartCoroutine(ChangeSpeed(barImage.fillAmount, barValue / maxBarValue, duration));
    }

    /// <summary>
    /// Change bar value (Invoked: StartBarChange void)
    /// </summary>
    /// <param name="newBarValue">Value to add</param>
    public void AddBarValue(float newBarValue)
    {
        barValue += newBarValue;
        StartSmoothBar();
    }
    
    /// <summary>
    /// Change bar value (Invoked: StartBarChange void)
    /// </summary>
    /// <param name="newBarValue">Value to substract</param>
    public void SubtractBarValue(float newBarValue)
    {
        barValue -= newBarValue;
        StartSmoothBar();
    }

    /// <summary>
    /// Change max bar value (Invoked: OnMaxBarValueChanged)
    /// </summary>
    /// <param name="newMaxBarValue"></param>
    public void SetMaxBarValue(float newMaxBarValue)
    {
        maxBarValue = newMaxBarValue;
        OnMaxBarValueChanged?.Invoke(maxBarValue);
    }
    
    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        OnBarValueChangeStart?.Invoke();
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            barImage.fillAmount = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            OnBarValueChanged?.Invoke(barImage.fillAmount);
            yield return null;
        }
        OnBarValueChangeEnd?.Invoke();
    }
    
    private void BarValueChange(float obj)
    {
        if (barValue > maxBarValue)
            barValue = maxBarValue;
        if (barValue < 0)
            barValue = 0;
    }
}
