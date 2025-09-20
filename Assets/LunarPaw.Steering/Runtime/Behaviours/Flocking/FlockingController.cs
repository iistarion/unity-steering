using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LunarPaw.Steering.Runtime.Agents
{
    public class FlockingController : MonoBehaviour
    {
        public List<FlockingAgent> FlockingAgents = new List<FlockingAgent>();
        public float NeighborDistance = 0.2f;
        public int BoidCount;
        public bool ShowRadius, ShowForces;
        public float AgentVelocity = 1f;

        public float AlignmentWeight, CohesionWeight, SeparationWeight;

        public FlockingAgent PrefabFlockingAgent;

        void Start()
        {
            var ch = GetComponentsInChildren<FlockingAgent>().ToList();
            if (ch.Count > 0)
            {
                var r = ch.Where(c => !FlockingAgents.Contains(c)).ToList();
                if (r.Count > 0)
                {
                    FlockingAgents.AddRange(r);
                }
            }
            else
            {
                GenerateBoids(BoidCount);
            }
        }

        public void GenerateBoids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var fa = Instantiate(PrefabFlockingAgent);
                fa.ShowForces = ShowForces;
                fa.AgentVelocity = AgentVelocity;
                fa.transform.parent = transform;
                var random = new System.Random();
                fa.Velocity = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f);
                fa.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0f);
                FlockingAgents.Add(fa);
            }
        }

        public void SetAgentCount(int count)
        {
            foreach (var c in FlockingAgents)
                Destroy(c.gameObject);
            FlockingAgents.Clear();
            GenerateBoids(count);
        }
        public FlockingAgent[] GetAllBehaviours()
        {
            return FindObjectsByType<FlockingAgent>(FindObjectsSortMode.None);
        }

        public void SetShowRadius(bool show)
        {
            ShowRadius = show;
        }

        void Update()
        {
            foreach (FlockingAgent agent in FlockingAgents)
            {
                var alignment = ComputeAlignment(agent);
                var cohesion = ComputeCohesion(agent);
                var separation = ComputeSeparation(agent);

                agent.Velocity += alignment * AlignmentWeight + cohesion * CohesionWeight + separation * SeparationWeight;

                agent.Velocity.Normalize();
                agent.Velocity = agent.Velocity * agent.AgentVelocity;
            }
        }

        public Vector3 ComputeAlignment(FlockingAgent currAgent)
        {
            var v = Vector3.zero;
            var neighborCount = 0;
            for (int i = 0; i < FlockingAgents.Count; i++)
            {
                var nextAgent = FlockingAgents[i];
                if (currAgent == FlockingAgents[i])
                    continue;

                if (Vector3.Distance(currAgent.transform.position, nextAgent.transform.position) < NeighborDistance)
                {
                    v += nextAgent.Velocity;
                    neighborCount++;
                }

            }
            if (neighborCount > 0)
            {
                v /= neighborCount;
                v.Normalize();
            }
            return v;
        }

        public Vector3 ComputeCohesion(FlockingAgent currAgent)
        {
            var v = Vector3.zero;
            var neighborCount = 0;
            for (int i = 0; i < FlockingAgents.Count; i++)
            {
                var nextAgent = FlockingAgents[i];
                if (currAgent == FlockingAgents[i])
                    continue;

                if (Vector3.Distance(currAgent.transform.position, nextAgent.transform.position) < NeighborDistance)
                {
                    v += nextAgent.transform.position;
                    neighborCount++;
                }

            }
            if (neighborCount > 0)
            {
                v /= neighborCount;
                v = new Vector3(v.x - currAgent.transform.position.x,
                    v.y - currAgent.transform.position.y,
                    v.z - currAgent.transform.position.z);
                v.Normalize();
            }
            return v;
        }

        public Vector3 ComputeSeparation(FlockingAgent currAgent)
        {
            var v = Vector3.zero;
            var neighborCount = 0;
            for (int i = 0; i < FlockingAgents.Count; i++)
            {
                var nextAgent = FlockingAgents[i];
                if (currAgent == nextAgent)
                    continue;


                var dst = Vector3.Distance(currAgent.transform.position, nextAgent.transform.position);
                if (dst < NeighborDistance)
                {
                    v += nextAgent.transform.position - currAgent.transform.position;
                    neighborCount++;
                }

            }
            if (neighborCount > 0)
            {
                v /= neighborCount;
                v *= -1;
                v.Normalize();
            }
            return v;
        }

        public void SetShowForces(bool value)
        {
            ShowForces = value;
            foreach (var steeringBehaviour in GetAllBehaviours())
            {
                steeringBehaviour.ShowForces = ShowForces;
            }
        }

        internal void SetAgentVelocity(float value)
        {
            AgentVelocity = value;
            foreach (var steeringBehaviour in GetAllBehaviours())
            {
                steeringBehaviour.AgentVelocity = AgentVelocity;
            }
        }
    }
}
