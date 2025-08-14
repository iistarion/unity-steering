using UnityEngine;

[RequireComponent(typeof(Boid))]    
public class ArriveBehaviour : MonoBehaviour, ISteeringBehaviour
{
    public Vector3 RotationOffset;
    public Transform Target;
    public float Radius = 2f;
    private Boid _boid;

    private void Awake()
    {
        _boid = GetComponent<Boid>();
    }

    private void FixedUpdate()
    {
        Steer(_boid);
    }

    public void Steer(Boid boid)
    {
        // Velocity to go to the target
        var desiredVelocity = (Target.position - boid.transform.position);
        var distance = desiredVelocity.magnitude;

        if (distance > Radius)
        {
            // If the target is far away, go at max speed
            desiredVelocity = desiredVelocity.normalized * boid.MaxSpeed;
        }
        else
        {
            // If the target is close, slow down
            desiredVelocity = desiredVelocity.normalized * (boid.MaxSpeed * (distance / Radius));
        }

        // Velocity to smoothly steer towards the target
        var steering = desiredVelocity - boid.Velocity;

        // Clamp by max force, the bigger MaxForce, the more the boid will turn
        steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
        steering /= boid.Mass;

        boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering, boid.MaxSpeed);
        boid.transform.position = boid.transform.position + boid.Velocity * Time.deltaTime;

        boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
    }
}
