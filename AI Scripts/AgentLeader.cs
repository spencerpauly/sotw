using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentLeader : MonoBehaviour
{
    [Range(0,400)]
    public int defaultAgentCount = 20;

    private Formation formation = null;
    private Team team;
    

    // Start is called before the first frame update
    void Awake() {
        formation = new Formation(new RectangleGenerator(8), this);
        team = GetComponent<Team>();

        if (GetComponent<NavMeshObstacle>() != null) {
            GetComponent<NavMeshObstacle>().radius = .8f;
        }
        
        //formation.Scale(2.0f);
    }

    void Start() {
        for (int i = 0; i < defaultAgentCount; i++) {
            AddAgent();
        }
    }

    private void AddAgent() {
        GameObject agent = ObjectPooler.Instance.Get("agent");
        agent.transform.position = transform.position + VectorPlus.ToVector3(Random.insideUnitCircle * 20);
        agent.transform.rotation = Quaternion.identity;
        agent.name = "Agent #" + formation.positions.Count;
        agent.tag = "Enemy";

        AgentController agentController = agent.GetComponent<AgentController>();
        agentController.leader = this;
        
        Team agentTeam = agent.GetComponent<Team>();
        if (agentTeam != null && team != null) {
            agentTeam.teamName = team.teamName;
        }

        formation.AddAgent(agentController);
    }

    public void removeAgent(AgentController agentToRemove) {
        formation.RemoveAgent(agentToRemove);
    }

    // Update is called once per frame
    void Update()
    {
        bool actionButtonPressed = InputManager.FireButton1();

        foreach (AgentController agent in formation.GetAgents()) {
            if (actionButtonPressed) {
                agent.GetComponent<WeaponEquip>().Toggle();
            }
            agent.SetDestination(formation.GetDestination(agent));       
        }

        if (InputManager.FireButton2()) {
            AddAgent();
        }
    }

    void OnDrawGizmos() {
        if (formation != null) {
            foreach(AgentController agent in formation.GetAgents()) {
                Gizmos.color = Color.white;
                Gizmos.DrawSphere(formation.ActualLocation(formation.positions[agent].location), 0.7f);
            }
        }
    }






}
