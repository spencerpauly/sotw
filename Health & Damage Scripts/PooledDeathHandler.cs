using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledDeathHandler : MonoBehaviour, IDeathHandler 
{
    public string pool;

    void Awake() {
        GetComponent<Health>().OnDeathEvent += Die;
    }

    public void Die() {
        ObjectPooler.Instance.ReturnToPool(pool, gameObject);
    }
}
