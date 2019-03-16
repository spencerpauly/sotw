using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Formation 
{
    public Dictionary<AgentController, Position> positions;
    public AgentLeader agentLeader;

    private FormationGenerator generator;
    
    public Formation(FormationGenerator generator, AgentLeader agentLeader) {
        this.generator = generator;
        this.agentLeader = agentLeader;
        positions = new Dictionary<AgentController, Position>();
    }

    public void AddAgent(AgentController agent) {
        Position nextPosition = generator.Next();
        positions.Add(agent, nextPosition);
    }

    //Todo(S) - refactor this and make work better for edge cases, will break if agent is last person in the list etc
    public void RemoveAgent(AgentController agent) {

        Dictionary<AgentController, Position> oldPositions = positions;

        positions = new Dictionary<AgentController, Position>();
        generator.count = 0;

        foreach(KeyValuePair<AgentController, Position> entry in oldPositions) {
            if (entry.Key != agent) {
                AddAgent(entry.Key);
            } 
        }
    }

    public List<AgentController> GetAgents() {
        return new List<AgentController>(positions.Keys);
    }

    public List<Position> GetPositions() {
        return new List<Position>(positions.Values);
    }

    public Vector3 GetDestination(AgentController agent) {
        if (!positions.ContainsKey(agent)) {
            Debug.Log("Agent " + agent + "does not exist in formation dictionary. Trying again.");
            AddAgent(agent);
            return GetDestination(agent);
        }        

        return ActualLocation(positions[agent].location);
    }


    protected void ApplyOffset(Vector3 offset) {
        foreach(KeyValuePair<AgentController, Position> p in positions) {
            positions[p.Key] = new Position(positions[p.Key].location + offset, positions[p.Key].priority);
        }
    }

    public void Scale(float scale) {
        foreach (KeyValuePair<AgentController, Position> p in positions) {
            positions[p.Key] = new Position(positions[p.Key].location * scale, positions[p.Key].priority);
        }
    }

    public Vector3 ActualLocation(Vector3 location) {
        return Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) *
                                    (location + generator.offset) + agentLeader.transform.position;
    }



}