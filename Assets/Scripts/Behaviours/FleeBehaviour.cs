using UnityEngine;

[RequireComponent(typeof(Boid))]    
public class FleeBehaviour : MonoBehaviour, ISteeringBehaviour
{
    public Vector3 RotationOffset;
    public Transform Target;
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
        var desiredVelocity = (boid.transform.position - Target.position).normalized;
        desiredVelocity *= boid.MaxSpeed;

        // Velocity to smoothly steer towards the target
        var steering = desiredVelocity - boid.Velocity;

        // Clamp by max force, the bigger MaxForce, the more the boid will turn
        steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
        steering /= boid.Mass;

        boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering, boid.MaxSpeed);
        boid.transform.position = boid.transform.position + boid.Velocity * Time.deltaTime;
        
        // Force z axis to 0 to keep the boid on a 2D plane
        boid.transform.position = new Vector3(boid.transform.position.x, boid.transform.position.y, 0);

        boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
    }
}
