using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour
{
    public AgentLeader leader;
    public ColorRenderer color;

    private NavMeshAgent navMesh;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        color = GetComponent<ColorRenderer>();
        GetComponent<Health>().OnDeathEvent += HandleDeath;
    }

    private void HandleDeath() {
        leader.removeAgent(this);
    }

    // Update is called once per frame
    public void SetDestination(Vector3 position) {
        navMesh.destination = position;
    }
}
