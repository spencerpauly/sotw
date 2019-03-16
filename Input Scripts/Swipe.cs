using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : OnScreenButton {

    public string direction;

    private void Awake() {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data) {
        if (direction == data.Direction.ToString()) {
            PressEvent();
        }
    }
}
