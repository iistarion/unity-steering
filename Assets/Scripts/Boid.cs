using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 Velocity;
    public Vector3 Acceleration;
    public float Mass;
    public float MaxSpeed = 5f;
    public float MaxForce = 0.1f;
}