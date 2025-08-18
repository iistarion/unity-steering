using LunarPaw.Steering.Runtime.Agents;
using UnityEngine;

namespace LunarPaw.Steering.Runtime.Behaviours
{
    [RequireComponent(typeof(Boid))]
    public class EvadeBehaviour : SteeringBehaviour
    {
        public Vector3 RotationOffset;
        public Boid Target;
        public GameObject DebugInterception;
        public float TimeInAdvance = 0.2f;
        public bool ShowDebugInterception;

        private void FixedUpdate()
        {
            Steer(_boid);
            DrawInterception();
        }

        override public void Steer(Boid boid)
        {
            var futurePosition = Target.transform.position + Target.Velocity * TimeInAdvance;
            var desiredVelocity = (boid.transform.position - futurePosition).normalized;
            desiredVelocity *= boid.MaxVelocity;
            var steering = desiredVelocity - boid.Velocity;
            steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
            steering /= boid.Mass;
            var rb = boid.GetComponent<Rigidbody>();
            boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering * Time.deltaTime, boid.MaxVelocity);
            boid.transform.position = boid.transform.position + boid.Velocity * Time.deltaTime;

            boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
        }

        public void DrawInterception()
        {
            DebugInterception.SetActive(ShowDebugInterception);
            DebugInterception.transform.position = Target.transform.position + Target.Velocity * TimeInAdvance;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _boid.transform.position = Vector3.zero;
        }
    }
}