using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public SmoothBar bar;

    private void Awake()
    {
        bar.OnBarValueChanged += OnBarChanged;
    }

    private void OnDisable()
    {
        bar.OnBarValueChanged -= OnBarChanged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            bar.AddBarValue(10);
        
        if (Input.GetKeyDown(KeyCode.Backspace))
            bar.SubtractBarValue(10);
    }

    public void OnBarChanged(float value)
    {
        Debug.Log(value);
    }
}
