using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    public Transform firePoint;

    private ProjectileCooldown cooldown;
    private Team team;

    void Awake() {
        cooldown = GetComponent<ProjectileCooldown>();
        team = GetComponent<Team>();
    }

    void Update() {
        if(InputManager.FireButton3()) {
            TryLaunch();
        }
    }

    public void TryLaunch() {
        if (!cooldown.IsCoolingDown()) {
            GameObject projectile = ObjectPooler.Instance.Get("projectile");
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            projectile.name = "Projectile";

            projectile.GetComponent<ProjectileMovement>().speed = speed;
            projectile.GetComponent<Team>().teamName = team.teamName;            

            cooldown.StartCooldown();
        }  
    }
}
