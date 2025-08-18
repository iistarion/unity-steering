using LunarPaw.Steering.Runtime.Agents;
using System;
using UnityEngine;

namespace LunarPaw.Steering.Runtime.Behaviours
{
    [RequireComponent(typeof(Boid))]
    public class SteeringBehaviour : MonoBehaviour
    {
        protected Boid _boid;

        private void Awake()
        {
            _boid = GetComponent<Boid>();
        }

        virtual public void Steer(Boid boid)
        {
            throw new NotImplementedException("Steer method must be implemented in derived classes.");
        }
    }
}