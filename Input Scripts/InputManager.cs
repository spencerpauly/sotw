using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {
    public static Joystick joystick { get; set; }
    public static bool jumpBtnPressed = false;

    //void Start() {
    //    SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    //}

    //private void SwipeDetector_OnSwipe(SwipeData data) {
    //    Debug.Log("Swipe in Direction: " + data.Direction);
    //}

    public static float Horizontal() {
        float returnValue = 0.0f;

        if (TouchscreenInput.GetHorizontal() != 0) {
            returnValue = TouchscreenInput.GetHorizontal();
        } else {
            returnValue = Input.GetAxis("Horizontal");
        }
        return returnValue;


    }

    public static float Vertical() {
        float returnValue = 0.0f;

        if (TouchscreenInput.GetVertical() != 0) {
            returnValue = TouchscreenInput.GetVertical();
        } else {
            returnValue = Input.GetAxis("Vertical");
        }
        return returnValue;
    }

    public static Vector3 GetJoystick() {
        return new Vector3(Horizontal(), 0, Vertical());
    }

    public static float JoystickScalar() {
        return Vector3.Distance(Vector3.zero, new Vector3(Horizontal(), Vertical()));
    }

    public static bool Jump()
    {
        if (jumpBtnPressed) {
            jumpBtnPressed = false;
            return true;
        } else {
            return Input.GetButtonDown("Jump");
        }
        
    }

    public static bool Sprint() {
        return Input.GetButton("Sprint");
    }

    public static bool FireButton1() {
        return Input.GetButtonDown("Fire1") || TouchscreenInput.GetButtonDown("Fire1");
    }

    public static bool UnfireButton1() {
        return Input.GetButtonUp("Fire1") || TouchscreenInput.GetButtonUp("Fire1");
    }

    public static bool FireButton2() {
        return Input.GetButtonDown("Fire2") || TouchscreenInput.GetButtonDown("Fire2");
    }

    public static bool FireButton3() {
        return Input.GetButtonDown("Fire3") || TouchscreenInput.GetButtonDown("Fire3"); ;
    }

    public static bool IsFiring() {
        return Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3");
    }

    public static bool SwipeLeft() {
        return Input.GetButtonDown("SwipeLeft") || TouchscreenInput.GetButtonDown("SwipeLeft");
    }

    public static bool SwipeRight() {
        return Input.GetButtonDown("SwipeRight") || TouchscreenInput.GetButtonDown("SwipeRight");
    }
}