using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public GameObject healthBarPrefab;
    public float heightOffset = 1.8f;
    public float defaultHealth;

    private Health health;

    void Start() {
        health = GetComponent<Health>();

        GameObject healthBar = Instantiate(
            healthBarPrefab, 
            transform.position + new Vector3(0,heightOffset,0), 
            transform.rotation) as GameObject;

        healthBar.transform.SetParent(transform);
        
        HealthBarUpdater healthBarUpdater = healthBar.GetComponent<HealthBarUpdater>();
        healthBarUpdater.health = health;
    }

}
