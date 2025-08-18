using LunarPaw.Steering.Runtime.Agents;
using UnityEngine;

namespace LunarPaw.Steering.Runtime.Behaviours
{
    [RequireComponent(typeof(Boid))]
    public class PursueBehaviour : SteeringBehaviour
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
            // Velocity to go to the target
            var futurePosition = Target.transform.position + Target.Velocity * TimeInAdvance;
            var desiredVelocity = (futurePosition - boid.transform.position).normalized;
            desiredVelocity *= boid.MaxVelocity;

            // Velocity to smoothly steer towards the target
            var steering = desiredVelocity - boid.Velocity;

            // Clamp by max force, the bigger MaxForce, the more the boid will turn
            steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
            steering /= boid.Mass;

            // Apply acceleration to current velocity
            boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering * Time.deltaTime, boid.MaxVelocity);

            // Update position and rotation
            boid.transform.position = boid.transform.position + boid.Velocity * Time.deltaTime;
            boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
        }

        public void DrawInterception()
        {
            DebugInterception.SetActive(ShowDebugInterception);
            DebugInterception.transform.position = Target.transform.position + Target.Velocity * TimeInAdvance;
        }
    }
}