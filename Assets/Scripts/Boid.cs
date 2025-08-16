using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 Velocity;
    public Vector3 Acceleration;
    public float Mass;
    public float MaxSpeed = 5f;
    public float MaxForce = 0.1f;

    private void OnDrawGizmos()
    {
        // Draw a line representing the velocity vector
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Velocity);
        // Draw a sphere at the position of the boid
        //Gizmos.color = Color.blue;
        //Gizmos.DrawSphere(transform.position, 0.1f);
    }
}