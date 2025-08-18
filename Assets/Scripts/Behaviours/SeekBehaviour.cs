using UnityEngine;

[RequireComponent(typeof(Boid))]    
public class SeekBehaviour : SteeringBehaviour
{
    public Vector3 RotationOffset;
    public Transform Target;

    private void FixedUpdate()
    {
        Steer(_boid);
    }

    override public void Steer(Boid boid)
    {
        // Velocity to go to the target
        var desiredVelocity = (Target.position - boid.transform.position).normalized;
        desiredVelocity *= boid.MaxVelocity;

        // Velocity to smoothly steer towards the target
        var steering = desiredVelocity - boid.Velocity;

        // Clamp by max force, the bigger MaxForce, the more the boid will turn
        steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
        steering /= boid.Mass;

        boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering * Time.deltaTime, boid.MaxVelocity);
        boid.transform.position = boid.transform.position + boid.Velocity * Time.deltaTime;

        boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
    }
}
