using LunarPaw.Steering.Runtime.Agents;
using UnityEngine;

namespace LunarPaw.Steering.Runtime.Behaviours
{
    [RequireComponent(typeof(Boid))]
    public class ArriveBehaviour : SteeringBehaviour
    {
        public Vector3 RotationOffset;
        public Transform Target;
        public float ArrivalRadius = 2f;
        public float StopRadius = 1e-4f;

        private void FixedUpdate()
        {
            Steer(_boid);
        }

        override public void Steer(Boid boid)
        {
            // Velocity to go to the target
            var desiredVelocity = (Target.position - boid.transform.position);
            var distance = desiredVelocity.magnitude;

            if (distance > ArrivalRadius)
            {
                // If the target is far away, go at max speed
                desiredVelocity = desiredVelocity.normalized * boid.MaxVelocity;
            }
            else if (distance > StopRadius)
            {
                // If the target is close, slow down
                desiredVelocity = desiredVelocity.normalized * (boid.MaxVelocity * (distance / ArrivalRadius));
            }
            else
            {
                // If the target is within the stop radius, stop
                desiredVelocity = Vector3.zero;
                boid.Velocity = Vector3.zero;
            }

            // Velocity to smoothly steer towards the target
            var steering = desiredVelocity - boid.Velocity;

            // Clamp by max force, the bigger MaxForce, the more the boid will turn
            steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
            steering /= boid.Mass;

            // Apply acceleration to current velocity
            boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering * Time.fixedDeltaTime, boid.MaxVelocity);

            // Update position and rotation
            boid.transform.position += boid.Velocity * Time.fixedDeltaTime;
            boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
        }
    }
}