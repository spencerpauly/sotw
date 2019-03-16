using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    public float speed { get; set; }

    private float lifetime = 0.0f;

    [SerializeField]
    private float maxLifetime = 10.0f;

    // Update is called once per frame

    void OnEnable() {
        lifetime = 0.0f;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime) {
            GetComponent<Health>().SetHealth(0);
        }
    }
}
