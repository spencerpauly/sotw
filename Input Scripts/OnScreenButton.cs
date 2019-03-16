using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenButton : MonoBehaviour {

    public string buttonName;

    private bool isPressed;
    private bool isOnPress;
    private bool isOnRelease;

    private float pressTime;
    private float releaseTime;
    private int defaultTime = 1;

    void Start() {
        TouchscreenInput.AddButton(this);
    }

    void LateUpdate() {
        if (isOnPress || isOnRelease) {
            UpdateTimes(-1);
        }
    }

    private void UpdateTimes(int updateNum) {
        pressTime += updateNum;
        releaseTime += updateNum;

        if (pressTime <= 0) {
            isOnPress = false;
        }
        if (releaseTime <= 0) {
            isOnRelease = false;
        }
    }

    public void PressEvent() {
        isPressed = true;
        isOnPress = true;
        pressTime = defaultTime;
    }

    public void ReleaseEvent() {
        isPressed = false;
        isOnRelease = true;
        releaseTime = defaultTime;
    }

    public bool GetButtonDown() {
        bool temp = isOnPress;
        //isOnPress = false;
        return temp;
    }

    public bool GetButton() {
        return isPressed;
    }

    public bool GetButtonUp() {
        bool temp = isOnRelease;
        //isOnRelease = false;
        return isOnRelease;
    }

}
