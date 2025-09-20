using LunarPaw.Steering.Runtime.Agents;
using System;
using UnityEngine;

namespace LunarPaw.Steering.Runtime.Behaviours.Steering
{
    [RequireComponent(typeof(SteeringAgent))]
    public class SteeringBehaviour : MonoBehaviour
    {
        protected SteeringAgent _boid;

        private void Awake()
        {
            _boid = GetComponent<SteeringAgent>();
        }

        virtual public void Steer(SteeringAgent boid)
        {
            throw new NotImplementedException("Steer method must be implemented in derived classes.");
        }
    }
}