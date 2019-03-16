using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCooldown : MonoBehaviour
{
    public float cooldown;
    private float currentCooldown;

    
    void Update() {
        if (currentCooldown > 0) {
            currentCooldown -= Time.deltaTime;
        }
        
    }

    public void StartCooldown() {
        currentCooldown = cooldown;
    }

    public bool IsCoolingDown() {
        return currentCooldown > 0;
    }



}
