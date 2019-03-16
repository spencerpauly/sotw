using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable 
{
    public float maxHealth = 20.0f;

    private float currentHealth;
    private IDeathHandler deathHandler;

    public event Action<float> OnHealthChangeEvent = delegate { };
    public event Action OnDeathEvent = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GetComponent<IDeathHandler>();
    }

    void OnEnable() {
        currentHealth = maxHealth;
        OnHealthChangeEvent(currentHealth);
    }

    public void TakeDamage(float damage) {
        SetHealth(currentHealth - damage);
    }

    public void SetHealth(float amount) {
        currentHealth = amount;
        OnHealthChangeEvent(currentHealth);

        if (currentHealth <= 0) {
            OnDeathEvent();
        }

    }

}
