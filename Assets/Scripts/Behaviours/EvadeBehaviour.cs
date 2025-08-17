using UnityEngine;

[RequireComponent(typeof(Boid))]    
public class EvadeBehaviour : MonoBehaviour, ISteeringBehaviour
{
    public Vector3 RotationOffset;
    public Boid Target;
    public GameObject DebugInterception;

    [SerializeField]
    private bool _showDebugInterception;
    [SerializeField]
    private float _timeInAdvance = 0.2f;
    private Boid _boid;

    private void Awake()
    {
        _boid = GetComponent<Boid>();
    }

    private void FixedUpdate()
    {
        Steer(_boid);
        DrawInterception();
    }

    public void Steer(Boid boid)
    {
        var futurePosition = Target.transform.position + Target.Velocity * _timeInAdvance;
        var desiredVelocity = (boid.transform.position - futurePosition).normalized;
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
        if (!_showDebugInterception)
            return;

        DebugInterception.SetActive(true);
        DebugInterception.transform.position = Target.transform.position + Target.Velocity * _timeInAdvance;
    }
}
