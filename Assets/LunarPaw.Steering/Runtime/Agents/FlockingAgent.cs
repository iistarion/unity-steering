using UnityEngine;

namespace LunarPaw.Steering.Runtime.Agents
{
    public class FlockingAgent : MonoBehaviour
    {
        public Vector3 RotationOffset = new Vector3(90f, 0f, 0f);
        public Vector3 Velocity;
        public float AgentVelocity = 1f;
        public int NeighborCount;
        private LineRenderer _forcesRenderer;
        public bool ShowForces;

        private void Awake()
        {
            _forcesRenderer = gameObject.GetComponent<LineRenderer>();
            _forcesRenderer.startWidth = 0.05f;
            _forcesRenderer.endWidth = 0.05f;
            _forcesRenderer.positionCount = 2;
            _forcesRenderer.startColor = _forcesRenderer.endColor = new Color(1f, 0f, 0f);
        }

        public void FixedUpdate()
        {
            transform.position += Velocity * Time.fixedDeltaTime;
            transform.rotation = Quaternion.LookRotation(Velocity.normalized, Vector3.up) * Quaternion.Euler(RotationOffset);
        }

        public void Update()
        {
            _forcesRenderer.enabled = ShowForces;
            if (ShowForces)
            {
                _forcesRenderer.SetPosition(0, transform.position);
                _forcesRenderer.SetPosition(1, transform.position + Velocity * 3f);
            }
        }
    }
}


