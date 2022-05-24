# SmoothBar
`This script is beta version`

### Features
- Advanced event system
- Editor menu system
- Docs

### Example (UNITY!!!)
```csharp
using UnityEngine;

public class test : MonoBehaviour
{
    // This is a bar script referance
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
        // Increase bar value by 10 when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            bar.AddBarValue(10);
            
        // Substract bar value by 10 when backspace is pressed
        if (Input.GetKeyDown(KeyCode.Backspace))
            bar.SubtractBarValue(10);
    }

    public void OnBarChanged(float value)
    {
        // Debug.Log bar value when bar value changed
        Debug.Log(value);
    }
}
```
