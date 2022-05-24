# SmoothBar
`This script is beta version`

## Releases
https://github.com/kayraegek18/SmoothBar/releases/tag/SmoothBar

### Features
- Advanced event system
- Custom Editor menu
- [Docs](https://basenodestudios.com "Docs")

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

### References
```csharp
barReferance.AddBarValue(valueToAdd); // Increase bar value
barReferance.SubstractBarValue(valueToSubstract); // Substract bar value
barReferance.SetMaxBarValue(valueToSync); // Set max bar value
barReferance.StartSmoothBar(); // Start bar smoother animation
```
