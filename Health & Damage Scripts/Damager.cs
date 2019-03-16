using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Damager : MonoBehaviour
{
    public float damage;

    [SerializeField]
    private Team team;

    [SerializeField]
    private bool destroyOnDamage = false;

    void Start() {
        team = GetComponentInParent<Team>(); 
    }

    void OnTriggerEnter(Collider col) {
        IDamagable damageableObject = col.gameObject.GetComponent<IDamagable>();
        Team otherTeam = col.gameObject.GetComponent<Team>();

        if (damageableObject != null && col.gameObject.tag == "Enemy") {
            if (team.teamName != otherTeam.teamName) {
                damageableObject.TakeDamage(damage);
                if (destroyOnDamage) {
                    GetComponent<Health>().SetHealth(0);
                }
            }
        }
    }
}
