using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpooledDeathHandler : MonoBehaviour, IDeathHandler
{
    void Awake() {
        GetComponent<Health>().OnDeathEvent += Die;
    }

    public void Die() {
        Destroy(gameObject);
    }
}
