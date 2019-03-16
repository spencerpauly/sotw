using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugSlider : MonoBehaviour
{
    public Text sliderValue;
    public Slider slider;

    void Awake() {
        sliderValue = GetComponentInChildren<Text>();
        slider = GetComponentInChildren<Slider>();
    }

    void Update() {
        sliderValue.text = slider.value.ToString("0.0");
    }
}
