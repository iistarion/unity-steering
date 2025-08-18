using UnityEngine;

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
        var futurePosition = Target.transform.position + Target.Velocity * TimeInAdvance;
        var desiredVelocity = (futurePosition - boid.transform.position).normalized;
        desiredVelocity *= boid.MaxVelocity;
        var steering = desiredVelocity - boid.Velocity;
        steering = Vector3.ClampMagnitude(steering, boid.MaxForce);
        steering /= boid.Mass;

        boid.Velocity = Vector3.ClampMagnitude(boid.Velocity + steering * Time.deltaTime, boid.MaxVelocity);
        boid.transform.position = boid.transform.position + boid.Velocity * Time.deltaTime;

        boid.transform.rotation = Quaternion.LookRotation(boid.Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
    }

    public void DrawInterception()
    {
        DebugInterception.SetActive(ShowDebugInterception);
        DebugInterception.transform.position = Target.transform.position + Target.Velocity * TimeInAdvance;
    }
}
