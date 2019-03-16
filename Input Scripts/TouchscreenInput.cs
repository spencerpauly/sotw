using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TouchscreenInput {

    private static Joystick joystick; //MAX = 1
    private static OnScreenButton[] buttons; //MAX = 20
    private static int buttonIndex;

    static TouchscreenInput() {
        buttons = new OnScreenButton[20];
        buttonIndex = 0;
    }

    //Add functions
    public static void AddButton(OnScreenButton button) {
        buttons[buttonIndex] = button;
        buttonIndex += 1;
    }

    public static void AddJoystick(Joystick newJoystick) {
        joystick = newJoystick;
    }

    public static float GetHorizontal() {
        return joystick.Horizontal;
    }

    public static float GetVertical() {
        return joystick.Vertical;
    }

    public static bool GetButtonDown(string buttonName) {
        foreach(OnScreenButton button in buttons) {
            if (button.buttonName == buttonName) {
                
                return button.GetButtonDown();
            }
        }
        Debug.Log("Error no button found by the name: " + buttonName);
        return false;
    }

    public static bool GetButton(string buttonName) {
        foreach (OnScreenButton button in buttons) {
            if (button.buttonName == buttonName) {
                return button.GetButton();
            }
        }
        Debug.Log("Error no button found by the name: " + buttonName);
        return false;
    }

    public static bool GetButtonUp(string buttonName) {
        foreach (OnScreenButton button in buttons) {
            if (button.buttonName == buttonName) {
                return button.GetButtonUp();
            }
        }
        Debug.Log("Error no button found by the name: " + buttonName);
        return false;
    }

}
