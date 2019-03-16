using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    void Update() {
        if (InputManager.FireButton1()) {
            Swing();
        }
    }

    private void Swing() {
        Debug.Log("Swung", this);
        //Execute swing animation, which should handle turning on and off collider too
    }

}
