using UnityEngine;

namespace LunarPaw.Steering.Runtime.Agents
{
    public class SteeringAgent : MonoBehaviour
    {
        public Vector3 Velocity;
        public bool ShowForces;
        public float Mass;
        public float MaxVelocity = 5f;
        public float MaxForce = 0.1f;
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            if (_lineRenderer == null)
                _lineRenderer = gameObject.AddComponent<LineRenderer>();
            _lineRenderer.startWidth = 0.05f;
            _lineRenderer.endWidth = 0.05f;
            _lineRenderer.positionCount = 2;
            Velocity = Vector3.zero;
        }

        private void Update()
        {
            if (ShowForces)
            {
                _lineRenderer.enabled = true;
                _lineRenderer.startColor = _lineRenderer.endColor = Color.green;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, transform.position + Velocity);
            }
            else
            {
                _lineRenderer.enabled = false;
            }
        }
    }
}